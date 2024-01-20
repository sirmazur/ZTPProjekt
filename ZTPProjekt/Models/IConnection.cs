using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public interface IConnection
    {
        Word Get();
        List<string> GetList(int amount);
        void Set(string word, string translation);
        void Remove(string word);
        string GetLanguage();
        int Length();

    }
}
