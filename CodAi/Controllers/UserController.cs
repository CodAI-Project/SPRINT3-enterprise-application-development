using CodAi.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace CodAi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private FirestoreDb _db;

        public UserController()
        {
            _db = FirestoreConnection.GetFirestoreDb();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult?> GetUser(string id)
        {
            DocumentReference documentReference = _db.Collection("user").Document(id);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();


            if (documentSnapshot.Exists)
            {
                //User user = new User();
                DocumentReference chatReferences = documentSnapshot.GetValue<DocumentReference>("chats");

                if (chatReferences != null)
                {
                    //foreach (var chatRef in chatReferences)
                    //{
                    //    // Obtenha o DocumentSnapshot do chat referenciado
                    //    DocumentSnapshot chatSnapshot = await chatRef.GetSnapshotAsync();

                    //    if (chatSnapshot.Exists)
                    //    {
                    //        // O documento de chat referenciado existe, agora você pode converter para o tipo Chat
                    //        Chat chat = chatSnapshot.ConvertTo<Chat>();

                    //        if (chat != null)
                    //        {
                    //            // Agora você pode usar o objeto Chat
                    //            string chatId = chat.Id;
                    //            string chatTitle = chat.title;

                    //            // Acesse a lista de histórico, se necessário
                    //            List<History> history = chat.history;
                    //            if (history != null)
                    //            {
                    //                return Ok(chat);
                    //            }
                    //        }

                    //    }
                    //}
                }
                User user = documentSnapshot.ConvertTo<User>();

                user.Id = documentSnapshot.Id;

                return Ok(user);
            }

            return BadRequest();
        }
    }
}
