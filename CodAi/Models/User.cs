using CodAi.Dto;
using Google.Cloud.Firestore;

namespace CodAi.Models
{
    [FirestoreData]
    public class User
    {
        public string ?Id { get; set; }

        [FirestoreProperty]
        public List<ChatDto> ?chats { get; set; }
    }
}
