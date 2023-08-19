using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodAi.Repositories
{
    internal interface IAnswer
    {
        string ReceiveQuestion(string question);
    }
}
