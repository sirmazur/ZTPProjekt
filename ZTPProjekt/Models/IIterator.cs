using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool HasNext();
        T CurrentQuestion();
    }
}
