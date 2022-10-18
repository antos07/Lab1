using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    internal class TextExpression : IExpression
    {
        private readonly string _value;

        public TextExpression(string value)
        {
            _value = value;
        }
        
        public string Calculate(ITable forTable)
        {
            return _value;
        }

        override public string ToString()
        {
            return _value;
        }
    }
}
