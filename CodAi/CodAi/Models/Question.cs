using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodAi.Models
{
    internal class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TypeLanguage TypeLanguage { get; set; }
        public Question() { }

    }

    enum TypeLanguage
    {
        ReactJS, NextJS, Angular, ReactNative
    }
}
