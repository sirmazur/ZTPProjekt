using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class QuestionIterator : IIterator<Question>
    {
        private ISet _questions;
        private int current = 0;
        public QuestionIterator(ISet questions)
        {
            _questions = questions;
        }
        public Question CurrentQuestion()
        {
            return _questions[current];
        }

        public Question First()
        {
            return _questions[0];
        }

        public bool HasNext()
        {
            if (current < _questions.Count-1)
                return true;
            else
                return false;
        }

        public Question Next()
        {
            return HasNext() ? _questions[++current] : null;
        }
    }
}
