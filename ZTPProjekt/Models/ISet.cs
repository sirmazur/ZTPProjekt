using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public interface ISet
    {
        IIterator<Question> CreateIterator();
        int Count { get; }
        Question this[int index] { get; }
    }
}
