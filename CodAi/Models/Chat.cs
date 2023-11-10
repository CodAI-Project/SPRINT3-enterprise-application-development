using Google.Cloud.Firestore;

namespace CodAi.Models
{
    [FirestoreData]
    public class Chat
    {
        //[FirestoreProperty]
        public string? Id { get; set; }

        [FirestoreProperty]
        public List<History>? history { get; set; }

        [FirestoreProperty]
        public string? title { get; set; }

        [FirestoreProperty]
        public long lastModified { get; set; }

        public Chat()
        {
            lastModified = (long)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }
}
