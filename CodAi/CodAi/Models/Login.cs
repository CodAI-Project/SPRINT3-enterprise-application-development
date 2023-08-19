using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodAi.Models
{
    internal class Login : User
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateAcess { get; set; }
    
        public Login() { }
    }
}
