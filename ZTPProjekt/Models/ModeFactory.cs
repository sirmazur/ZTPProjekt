using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class ModeFactory
    {
        public static IMode GetMode(string name)
        {
            switch(name) 
            {
                case "Study":
                    return new Study();
                    break;
                case "Test":
                    return new Test();
                    break;
                default:
                    throw new ArgumentException("This mode doesnt exist.");
            }
        }
    }
}
