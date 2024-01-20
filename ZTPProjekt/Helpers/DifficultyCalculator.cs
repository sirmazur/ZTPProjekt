using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPProjekt.Models;

namespace ZTPProjekt.Helpers
{
    public class DifficultyCalculator
    {
        public static Difficulty GetDifficulty(int skillLevel)
        {
            if (skillLevel >= 0 && skillLevel <= 20)
                return Difficulty.Novice;
            else if (skillLevel > 20 && skillLevel <= 40)
                return Difficulty.Beginner;
            else if (skillLevel > 40 && skillLevel <= 40)
                return Difficulty.Intermediate;
            else if (skillLevel > 60 && skillLevel <= 40)
                return Difficulty.Advanced;
            else if (skillLevel > 80 && skillLevel <= 40)
                return Difficulty.Expert;
            else
                return Difficulty.Master; 
        }
    }
}
