using CodAi.Models;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace CodAi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        private FirestoreDb _db;

        public ChatController()
        {
            _db = FirestoreConnection.GetFirestoreDb();
        }

        [HttpGet]
        public async Task<List<Chat?>> GetAllChat()
        {

            Query chatsref = _db.Collection("chat");
            QuerySnapshot snapshot = await chatsref.GetSnapshotAsync();
            List<Chat?> chats = new List<Chat?>();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                Chat newChat = documentSnapshot.ConvertTo<Chat>();

                newChat.Id = documentSnapshot.Id;

                Dictionary<string, object> chat = documentSnapshot.ToDictionary();
                foreach (KeyValuePair<string, object> c in chat)
                {
                    if (c.Key.ToLower() == "title")
                    {
                        newChat.title = (string)c.Value;
                    }
                    if (c.Key.ToLower() == "history")
                    {
                        List<History> listHistory = new List<History>();
                        object valor = c.Value;

                        if (valor is List<object> historyList)
                        {
                            foreach (var item in historyList)
                            {
                                if (item is Dictionary<string, object> historyItem)
                                {
                                    History historyEntry = new History();

                                    if (historyItem.TryGetValue("role", out object roleValue) && roleValue is string role)
                                    {
                                        historyEntry.role = role;
                                    }

                                    if (historyItem.TryGetValue("content", out object contentValue) && contentValue is string content)
                                    {
                                        historyEntry.content = content;
                                    }

                                    listHistory.Add(historyEntry);
                                }
                            }
                        }

                        newChat.history = listHistory;
                    }

                    if (c.Key.ToLower() == "lastmodified") {
                        newChat.lastModified = (long)c.Value;
                    }

                }
                chats.Add(newChat);
            }

            return chats;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult?> GetChat(string id)
        {
            DocumentReference documentReference = _db.Collection("chat").Document(id);
            DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {

                Chat? chat = documentSnapshot.ConvertTo<Chat>();
                chat.Id = documentSnapshot.Id;
                return Ok(chat);
            }

            return NotFound();
        }


        // POST: api/Chat
        [HttpPost]
        public async Task<IActionResult?> CreateChat(Chat chat)
        {
            try
            {
                DocumentReference docReference = _db.Collection("chat").Document();
                await docReference.SetAsync(chat);
                return Ok("Inserido com sucesso!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT: api/Chat
        [HttpPut]
        public async Task<IActionResult?> UpdateChat(Chat chat)
        {
            try
            {
                DocumentReference documentReference = _db.Collection("chat").Document(chat.Id);
                DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    await documentReference.SetAsync(chat, SetOptions.Overwrite);
                    return Ok("Chat alterado com sucesso!");
                }
                else
                {
                    return NotFound("Chat não encontrado.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/Chat/id
        [HttpDelete("{id}")]
        public async Task<IActionResult?> DeleteChat(string id)
        {
            try
            {
                DocumentReference documentReference = _db.Collection("chat").Document(id);
                DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    await documentReference.DeleteAsync();
                    return Ok("Chat deletado com sucesso!");
                }
                else
                {
                    return NotFound("Chat não encontrado.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
