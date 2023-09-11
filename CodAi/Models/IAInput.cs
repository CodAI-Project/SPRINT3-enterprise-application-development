namespace CodAi.Models
{
    public class IAInput
    {
        public string ?model { get; set; }

        public List<History> ?messages { get; set; }

        public int max_tokens { get; set; }

        public decimal temperature { get; set; }

        public IAInput(List<History> messages) {
            this.messages = messages;
            temperature = 0.7m;
            max_tokens = 2000;
            model = "gpt-3.5-turbo";
        }
    }

    //public class Message 
    //{ 
    //    public List<History> ?Historys { get; set; }

    //    public Message(List<History> historys) {
    //        Historys = historys;
    //    }
    //}
}
