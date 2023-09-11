using Google.Cloud.Firestore;

namespace CodAi.Models
{
    [FirestoreData]
    public class User
    {
        //[FirestoreProperty]
        public string ?Id { get; set; }

        [FirestoreProperty]
        public string ?email { get; set; }

        [FirestoreProperty]
        public string ?senha{ get; set; }

        [FirestoreProperty]
        public List<Chat> ?chats { get; set; }
    }
}
