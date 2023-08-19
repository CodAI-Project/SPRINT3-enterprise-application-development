using CodAi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodAi.Repositories
{
    internal interface IChat
    {
        IList<Answer> ListAnswers();

        IList<Question> ListQuestions();
    }
}
