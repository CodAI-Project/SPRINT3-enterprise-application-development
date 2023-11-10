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
        public async Task<IActionResult> PostResponseIA(Chat chat, [FromServices] IConfiguration configuration)
        {
            var token = configuration.GetValue<string>("ChatGPTSecretKey");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            List<History> historys = new List<History>();

            foreach (History hist in TratamentIAInterationUser(chat))
            {
                if (historys.Count() == 1)
                {
                    Frameworks frameworks = new Frameworks();
                    string contenFirst = FirstPrompt(hist.content, frameworks.Template);
                    History history = new History
                    {
                        content = contenFirst,
                        role = "system"
                    };
                    historys.Add(history);
                }
                else {
                    GeneratorUsingHistoryPrompt(hist.content);
                }

                historys.Add(hist);
            }

            IAInput ia = new IAInput(historys);

            var requestBody = JsonConvert.SerializeObject(ia);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            var result = await response.Content.ReadFromJsonAsync<IAShow>();

            var promptResponse = result?.choices.First();

            chat.history.Add(promptResponse.message);

            ChatController chatController = new ChatController();

            chatController.UpdateChat(chat);

            return Ok(promptResponse.message);
        }


        public List<History> TratamentIAInterationUser(Chat chat)
        {


            List<History> listHistory = new List<History>();

            int numberOfItemsToTake = 6;


            IEnumerable<History> lastSixHistory = chat.history.Skip(Math.Max(0, chat.history.Count - numberOfItemsToTake)).Take(numberOfItemsToTake);

            listHistory.AddRange(lastSixHistory);

            return listHistory;

        }

        public string FirstPrompt(string ask, string template)
        {
            return @"
            **Instrução:**
            
            Você é um gerador de template de react e deve fazer um template de acordo com o qual o usuário solicitou, faça tudo com boas práticas e tudo que você importar no componente deve existir, siga as boas práticas e realize tudo o que o usuário pedir
            -Não se esqueça de importar tudo que usar, pois se não realizar isso ele dá erro no editor, pois esse objeto deve ser capaz de funcionar no stackblitz,  e deve retornar exatamente o objeto solicitado, pois se não derá erro e o usuário não vai gostar da sua utilização
            
            - Tudo deve ser responsivo, pois se não o usuário não vai gostar de utilizar a plataforma
            
            - No atributo 'title' e 'description' você deve realizar o preenchimento também de acordo com o que o usuário solicitou, atenção aos detalhes e seja bem caprichoso
            
            - Não utilize template strings com acentos, pois eles quebram o código, e por favor, retorne apenas o objeto, nunca retorne frases explicando o código, apenas o objeto com o que foi solicitado
            
            NÃO ESQUEÇA DOS IMPORTES NAS ROTAS TAMBÉM
            
            O objeto deve ser a única coisa a ser retornada
            
            ** O que retornar?**
            
            Apenas o objeto usado de exemplo logo abaixo
            {
                ""files"": {
                    ""src/index.js"": """",
                    ""src/App.js"": """",
                    ""public/index.html"": """",
                    ""package.json"": """"
                },
                ""title"": """",
                ""description"": """",
                ""template"": """ + template + @""",
                ""dependencies"": {
                    ""react"": ""18.2.0"",
                    ""react-dom"": ""18.2.0"",
                    ""react-scripts"": ""5.0.1"",
                    ""react-router-dom"": ""6.6.2""
                }
            }
            
            **SOLICITAÇÃO DO USUÁRIO ABAIXO * *
            " + ask + ";";
        }

        public string GeneratorUsingHistoryPrompt(string ask)
        {


            return @"** Requisitos **

          Levando em consideração as ultimas conversas do usuario, e a solicitação do sistema

          faça as modificações do objeto files

          não esqueça de nenhum import



          ajuste o objeto e mande novamente, mude só o atributo de files

          *** ATENÇÃO, NÃO RETORNE NADA ALEM DO OBJETO.POIS ISSO QUEBRA O CODIGO***

          modificações solicitadas pelo usuario:" + ask;
        }
    }
}
