using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class Word
    {
        public Word(string pWord, string fWord, string lang) 
        {
            PolishWord = pWord;
            ForeignWord = fWord;
            Language = lang;
        }
        public string PolishWord { get; set; }
        public string ForeignWord { get; set; }
        public string Language { get;}
    }
}
