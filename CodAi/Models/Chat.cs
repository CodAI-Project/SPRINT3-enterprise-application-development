using Google.Cloud.Firestore;

namespace CodAi.Models
{
    [FirestoreData]
    public class Chat
    {
        [FirestoreProperty]
        public string? Id { get; set; }

        [FirestoreProperty]
        public List<History>? history { get; set; }


        [FirestoreProperty]
        public string? title { get; set; }

        //public Chat() { }

    }
}
