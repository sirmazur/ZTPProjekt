using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class QuestionGenerator 
    {
        public static List<Question> CreateToPolish(Difficulty difficulty, string language)
        {
            var connection = Vocabulary.GetConnection(language);
            IConnection decorator = new ForeignToPolishDecorator(connection);
            List<Question> questionList = new List<Question>();
            

            for(int i=0;i<10;i++)
            {
                if (difficulty==Difficulty.None || difficulty == Difficulty.Master)
                {
                    var result = decorator.GetList(1);
                    List<(string, bool)> answerList = new List<(string, bool)>();
                    answerList.Add((result[0], true));
                    WordAnswer word = new WordAnswer(result[1], answerList);
                    questionList.Add(new Question(word, difficulty));
                }
                else
                {
                    var result = decorator.GetList((int)difficulty+2);
                    List<(string, bool)> answerList = new List<(string, bool)>();
                    answerList.Add((result[0], true));
                    for (int j = 2; j<(int)difficulty+2; j++)
                        answerList.Add((result[j], false));
                    WordAnswer word = new WordAnswer(result[1], answerList);
                    questionList.Add(new Question(word, difficulty));
                }
            }
            return questionList;
        }

        public static List<Question> CreateFromPolish(Difficulty difficulty, string language)
        {
            var connection = Vocabulary.GetConnection(language);
            IConnection decorator = new PolishToForeignDecorator(connection);
            List<Question> questionList = new List<Question>();


            for (int i = 0; i<10; i++)
            {
                if (difficulty==Difficulty.None || difficulty == Difficulty.Master)
                {
                    var result = decorator.GetList(1);
                    List<(string, bool)> answerList = new List<(string, bool)>();
                    answerList.Add((result[1], true));
                    WordAnswer word = new WordAnswer(result[0], answerList);
                    questionList.Add(new Question(word, difficulty));
                }
                else
                {
                    var result = decorator.GetList((int)difficulty+2);
                    List<(string, bool)> answerList = new List<(string, bool)>();
                    answerList.Add((result[1], true));
                    for (int j = 2; j<(int)difficulty+2; j++)
                        answerList.Add((result[j], false));
                    WordAnswer word = new WordAnswer(result[0], answerList);
                    questionList.Add(new Question(word, difficulty));
                }
            }
            return questionList;
        }
    }
}
