using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    abstract class AbstractConnection
    {
        public abstract List<string> GetList(int amount);
    }
}
