using Figgle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPProjekt.Helpers;
using ZTPProjekt.UI;

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

        public async Task Run(bool fromPolish, string language, Difficulty difficulty)
        {
            bool answeredCorrectly = false;
            Console.Clear();
            List<Question> questions = new List<Question>();
            if(fromPolish) 
            {
                questions = QuestionGenerator.CreateFromPolish(Difficulty.Intermediate, language);
            }
            else
            {
                questions = QuestionGenerator.CreateToPolish(Difficulty.Intermediate, language);
            }
            ISet set = new Set(questions);
            var iterator = set.CreateIterator();
            List<Option> options = new List<Option>();
            var wordAnswer = iterator.CurrentQuestion().WordAnswer;
            foreach (var answer in ListShuffler.Shuffle<(string, bool)>(wordAnswer.WordCorrectness))
            {
                options.Add(new Option(FiggleFonts.Slant.Render(wordAnswer.WordQuestion+" => "+answer.Item1),() => Task.Run(() => {
                    if (answer.Item2 is true)
                    {
                        if (ProgressLanguage.ContainsKey(language))
                        {
                            var progress = ProgressLanguage.FirstOrDefault(p => p.Key==language).Value;
                            progress++;
                        }
                        else
                        {
                            ProgressLanguage.Add(language, 1);
                        }
                        answeredCorrectly=true;
                        Console.Clear();
                        Console.WriteLine(FiggleFonts.Slant.Render("Correct!"));
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(FiggleFonts.Slant.Render("Wrong!"));
                        Thread.Sleep(1000);
                    }
                })));
            }
            do { answeredCorrectly = false; await MenuBuilder.CreateSingularMenu(options); }
            while (answeredCorrectly is false);
            while (iterator.HasNext())
            {
                options.Clear();
                wordAnswer = iterator.Next().WordAnswer;
                foreach (var answer in ListShuffler.Shuffle<(string, bool)>(wordAnswer.WordCorrectness))
                {
                    options.Add(new Option(FiggleFonts.Slant.Render(wordAnswer.WordQuestion+" => "+answer.Item1), async () => await Task.Run(async () => {
                        if (answer.Item2 is true)
                        {
                            if (ProgressLanguage.ContainsKey(language))
                            {
                                var progress = ProgressLanguage.FirstOrDefault(p => p.Key==language).Value;
                                progress++;
                            }
                            else
                            {
                                ProgressLanguage.Add(language, 1);
                            }
                            answeredCorrectly = true;
                            Console.Clear();
                            Console.WriteLine(FiggleFonts.Slant.Render("Correct!"));
                            await Task.Delay(1000);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(FiggleFonts.Slant.Render("Wrong!"));
                            await Task.Delay(1000);
                        }
                    })));
                }
                do { answeredCorrectly = false; await MenuBuilder.CreateSingularMenu(options); }
                while (answeredCorrectly is false);
            }
        }
    }
}
