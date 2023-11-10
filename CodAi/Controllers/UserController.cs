using CodAi.Dto;
using CodAi.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System;

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
                User user = new User();
                Dictionary<string, object> userData = documentSnapshot.ToDictionary();
                user.Id = documentSnapshot.Id;

                if (userData != null)
                {

                    List<ChatDto> listChat = new List<ChatDto>();
                    ChatController chatController = new ChatController();

                    if (userData.ContainsKey("chats") && userData["chats"] is object chat)
                    {
                        Console.Write(chat);
                        if (chat is Dictionary<string, object> chatData)
                        {
                            foreach (KeyValuePair<string, object> c in chatData)
                            {
                                DocumentReference docChat = (DocumentReference)c.Value;
                                ChatDto newChat = new ChatDto();
                                newChat.Id = docChat.Id;

                                listChat.Add(newChat);
                            }
                        }
                    }

                    user.chats = listChat;
                    return Ok(user);
                }
            }

            return BadRequest();

        }

    }
}