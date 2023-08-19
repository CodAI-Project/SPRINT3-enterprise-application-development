using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodAi.Models
{
    internal class Chat
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime LastModified { get; set; }

        public List<Question> Questions { get; set; }

        public List<Answer> Answers { get; }

        public Role Role { get; set; }


        public Chat() { }
    }

    enum Role
    {
        System, Assistant, User
    }

}
