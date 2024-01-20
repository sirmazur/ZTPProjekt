using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class Vocabulary
    {
        private static Vocabulary? _instance;
        private List<Word> Words = new List<Word>();
        private Vocabulary() { }
        public static List<string> GetLanguages()
        {
            return _instance.Words.Select(w => w.Language).Distinct().ToList();
        }
        public static IConnection GetConnection(string language)
        {
            if (_instance == null)
            {
                _instance = new Vocabulary();
            }
            return Connection.getInstance(language);
        }
        internal class Connection : AbstractConnection, IConnection
        {
            private static List<IConnection> Connections = new List<IConnection>();
            public string Language {  get;}
            private Connection(string language)
            {
                Language=language;
            }

            public static IConnection getInstance(string language)
            {

                if (!Connections.Any(c=>c.GetLanguage()==language))
                {
                    Connections.Add(new Connection(language));
                    return Connections.Last();
                }
                else
                {
                    var connection = Connections.FirstOrDefault(c => c.GetLanguage()==language);
                    if (connection is not null)
                        return connection;
                    else
                        throw new Exception($"Connection with language {language} doesnt exist.");
                }

            }
            public string GetLanguage()
            {
                return Language;
            }
            public Word Get()
            {
                var words = _instance.Words.Where(w => w.Language==Language).ToList();
                var random = new Random();
                int number = random.Next(0, words.Count);
                var randomWord = words[number];
                return randomWord;
            }

            public override List<string> GetList(int amount)
            {              
                var words = _instance.Words.Where(w => w.Language==Language).ToList();
                if (amount>words.Count())
                {
                    throw new Exception("Not enough words in database.");
                }
                List<string> list = new List<string>();
                for (int i= 0; i < amount; i++)
                {
                    var random = new Random();
                    int number = random.Next(0, words.Count);
                    list.Add(words[number].PolishWord);
                    list.Add(words[number].ForeignWord);
                    words.RemoveAt(number);
                }
                return list;
            }

            public int Length()
            {
                return _instance.Words.Count();
            }

            public void Remove(string word)
            {
                var wordToRemove = _instance.Words.FirstOrDefault(w => w.PolishWord==word);
                _instance.Words.Remove(wordToRemove);
            }

            public void Set(string word, string translation)
            {
                if(!_instance.Words.Any(w => w.PolishWord==word&&w.Language==Language))
                {
                    _instance.Words.Add(
                        new Word(word, translation, Language));
                }
                else
                {
                    _instance.Words.FirstOrDefault(w => w.PolishWord==word&&w.Language==Language).PolishWord=word;
                    _instance.Words.FirstOrDefault(w => w.PolishWord==word&&w.Language==Language).ForeignWord=translation;
                }
            }
        }
    }
}
