using CodAi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CodAi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IAController : Controller
    {

        private readonly HttpClient _httpClient;
        public IAController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<string> PostResponseIA(Chat chat, [FromServices] IConfiguration configuration)
        {
            var token = configuration.GetValue<string>("ChatGPTSecretKey");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            List<History> historys = new List<History>();

            foreach (History hist in chat.history) {
                historys.Add(hist);
            }

            IAInput ia = new IAInput(historys);

            var requestBody = JsonConvert.SerializeObject(ia);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            var result = await response.Content.ReadFromJsonAsync<IAShow>();

            var promptResponse = result?.choices.First();

            return promptResponse.message.content.Replace("\n", "").Replace("\t", "");
        }
    }
}
