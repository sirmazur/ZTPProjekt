using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class Study : IMode
    {
        private Dictionary<string,int> ProgressLanguage = new Dictionary<string,int>();
        public int GetLanguageProgress(string language)
        {
            if(!ProgressLanguage.ContainsKey(language))
            {
                return 0;
            }
            var item = ProgressLanguage.FirstOrDefault(p => p.Key == language);
            return item.Value;
        }

        public Task Run(bool fromPolish, string language, Difficulty difficulty)
        {
            Console.Clear();
            List<Question> questions = new List<Question>();
            if(fromPolish) 
            {
                questions = QuestionGenerator.CreateFromPolish(Difficulty.None, language);
            }
            else
            {
                questions = QuestionGenerator.CreateToPolish(Difficulty.None, language);
            }
            ISet set = new Set(questions);
            var iterator = set.CreateIterator();
            Console.WriteLine(iterator.CurrentQuestion().WordAnswer.WordQuestion+" => "+iterator.CurrentQuestion().WordAnswer.WordCorrectness[0].Item1);
            Console.ReadKey();
            while(iterator.HasNext()) 
            {
                Console.Clear();
                var next = iterator.Next();
                Console.WriteLine(next.WordAnswer.WordQuestion+" => "+next.WordAnswer.WordCorrectness[0].Item1);
                Console.ReadKey();
                if(ProgressLanguage.ContainsKey(language))
                {
                    var progress = ProgressLanguage.FirstOrDefault(p => p.Key==language).Value;
                    progress++;
                }
                else
                {
                    ProgressLanguage.Add(language, 1);
                }
            }
            return Task.CompletedTask;
        }
    }
}
