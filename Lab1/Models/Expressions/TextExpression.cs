using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    public class TextExpression : IExpression
    {
        private readonly string _value;

        public TextExpression(string value)
        {
            _value = value;
        }

        public HashSet<string> ReferencedCells => new HashSet<string>();

        virtual public object Calculate(ITable forTable)
        {
            return false;
        }

        override public string ToString()
        {
            return _value;
        }
    }
}
