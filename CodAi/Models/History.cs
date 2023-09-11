using Google.Cloud.Firestore;

namespace CodAi.Models
{
    [FirestoreData]
    public class History
    {
        [FirestoreProperty]
        public string role{ get; set; }
        [FirestoreProperty]
        public string ?content { get; set; }

    }

    //public enum Role
    //{
    //    system,
    //    user,
    //    assistant
    //}
}
