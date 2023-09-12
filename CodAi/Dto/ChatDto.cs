using Google.Cloud.Firestore;

namespace CodAi.Dto
{
    [FirestoreData]
    public class ChatDto
    {
        [FirestoreProperty]
        public string? Id { get; set; }
    }
}
