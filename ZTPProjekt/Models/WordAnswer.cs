using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class WordAnswer
    {
        public WordAnswer(string wordq,List<(string,bool)> wordc) 
        {
            WordQuestion = wordq;
            WordCorrectness = wordc;
        }
        public string WordQuestion {  get; set; }
        public List<(string,bool)> WordCorrectness { get; set; }
    }
    public enum Difficulty
    {   
        None,
        Novice,
        Beginner,
        Intermediate,
        Advanced,
        Expert,
        Master
    }
}
