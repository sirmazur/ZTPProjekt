using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class Set : ISet
    {
        private List<Question> questions = new List<Question>();
        public Set(List<Question> _questions) 
        {
            questions = _questions;
        }
        public IIterator<Question> CreateIterator()
        {
            return new QuestionIterator(this);
        }

        public int Count => questions.Count();

        public Question this[int index] => questions[index];
    }
}
