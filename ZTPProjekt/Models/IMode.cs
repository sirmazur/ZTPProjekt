using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public interface IMode
    {
        Task Run(bool fromPolish, string language, Difficulty difficulty);
    }
}
