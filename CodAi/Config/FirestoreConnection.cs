using Google.Cloud.Firestore;

namespace CodAi
{
    public static class FirestoreConnection
    {
        public static FirestoreDb ?_db;
        private static string directory = "C:\\Users\\Daniele\\Desktop\\2-ano-facul\\C#\\CodAi-backend-csharp\\CodAi\\appsettings.Development.json";
        public static FirestoreDb GetFirestoreDb()
        {
            if (_db == null)
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", directory);
                _db = FirestoreDb.Create("codai-development-csharp");
            }

            return _db;
        }

    }
}