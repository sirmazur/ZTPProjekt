using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPProjekt.Helpers;
using ZTPProjekt.UI;
namespace ZTPProjekt.Models
{
    public class Test : IMode
    {
        private List<Question> questions = new List<Question>();
        private int correctAnswers = 0;
        public async Task Run(bool fromPolish, string language, Difficulty difficulty)
        {
            Console.Clear();
            List<Question> questions = new List<Question>();
            correctAnswers = 0;
            if (fromPolish)
            {
                questions = QuestionGenerator.CreateFromPolish(difficulty, language);
            }
            else
            {
                questions = QuestionGenerator.CreateToPolish(difficulty, language);
            }
            ISet set = new Set(questions);
            var iterator = set.CreateIterator();
            if (difficulty==Difficulty.Master)
            {
                Console.WriteLine(iterator.CurrentQuestion().WordAnswer.WordQuestion+":");
                var answer = Console.ReadLine();
                var correct = iterator.CurrentQuestion().WordAnswer.WordCorrectness[0].Item1;
                if (answer == correct)
                {
                    correctAnswers++;
                    Console.WriteLine("Correct!");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Wrong!");
                    Thread.Sleep(1000);
                }
                while (iterator.HasNext())
                {
                    Console.Clear();
                    var question = iterator.Next();
                    Console.WriteLine(question.WordAnswer.WordQuestion+":");
                    answer = Console.ReadLine();
                    if (answer == iterator.CurrentQuestion().WordAnswer.WordCorrectness[0].Item1)
                    {
                        correctAnswers++;
                        Console.WriteLine("Correct!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Wrong!");
                        Thread.Sleep(1000);
                    }
                }
            }
            else
            {
                List<Option> options = new List<Option>();
                var wordAnswer = iterator.CurrentQuestion().WordAnswer;
                foreach (var answer in ListShuffler.Shuffle<(string,bool)>(wordAnswer.WordCorrectness))
                {
                    options.Add(new Option(wordAnswer.WordQuestion+"=>"+answer.Item1, () => Task.Run(async () => {
                        if (answer.Item2 is true)
                        {
                            correctAnswers++;
                            Console.WriteLine("Correct!");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine("Wrong!");
                            Thread.Sleep(1000);
                        }
                    })));
                }
                await MenuBuilder.CreateSingularMenu(options);                
                while(iterator.HasNext())
                {
                    options.Clear();
                    wordAnswer = iterator.Next().WordAnswer;
                    foreach (var answer in ListShuffler.Shuffle<(string, bool)>(wordAnswer.WordCorrectness))
                    {
                        options.Add(new Option(wordAnswer.WordQuestion+"=>"+answer.Item1,async () =>await Task.Run(async () => {
                            if (answer.Item2 is true)
                            {
                                correctAnswers++;
                                Console.WriteLine("Correct!");
                                await Task.Delay(1000);
                            }
                            else
                            {
                                Console.WriteLine("Wrong!");
                                await Task.Delay(1000);
                            }
                        })));
                    }
                    await MenuBuilder.CreateSingularMenu(options);
                }
            }
            Console.WriteLine("Your result: "+correctAnswers+"/10");
            Thread.Sleep(5000);
        }


    }
}
