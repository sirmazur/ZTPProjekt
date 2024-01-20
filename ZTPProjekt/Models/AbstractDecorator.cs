using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public abstract class AbstractDecorator : IConnection
    {
        protected IConnection _connection;
        public AbstractDecorator(IConnection connection)
        {
            _connection = connection;
        }

        public Word Get()
        {
            return _connection.Get();
        }

        public string GetLanguage()
        {
            return _connection.GetLanguage();
        }

        public virtual List<string> GetList(int amount)
        {
            return _connection.GetList(amount);
        }

        public int Length()
        {
            return _connection.Length();
        }

        public void Set(string word, string translation)
        {
            _connection.Set(word, translation);
        }

        public void Remove(string word) 
        {
            _connection.Remove(word);
        }
    }
}
