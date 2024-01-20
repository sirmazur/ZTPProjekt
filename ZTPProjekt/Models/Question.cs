using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class Question
    {
        public WordAnswer WordAnswer { get; set; }
        public Difficulty Difficulty { get; set; }
        public Question(WordAnswer wordAnswer, Difficulty difficulty) 
        {
            WordAnswer = wordAnswer;
            Difficulty = difficulty;
        }
    }
}
