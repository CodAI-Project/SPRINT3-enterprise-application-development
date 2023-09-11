using Google.Cloud.Firestore;

namespace CodAi.Models
{
    [FirestoreData]
    public class Frameworks
    {
        public string? Id { get; set; }
        
        [FirestoreProperty]
        public string? Template { get; set; }
        
        [FirestoreProperty]
        public string? Framework { get; set; }

        public Frameworks() { }
    }

}
