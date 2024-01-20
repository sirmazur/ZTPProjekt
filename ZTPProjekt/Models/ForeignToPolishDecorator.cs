using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProjekt.Models
{
    public class ForeignToPolishDecorator : AbstractDecorator
    {
        public ForeignToPolishDecorator(IConnection connection) : base(connection) { }

        public override List<string> GetList(int amount)
        {
            var words = base.GetList(amount);
            for (int i = words.Count()-1; i >= 0; i--)
            {
                if (i>2 && i%2==1)
                {
                    words.RemoveAt(i);
                }
            }
            return words;
        }
    }
}
