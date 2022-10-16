using Lab1.Models.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Parsers
{
    public class SimpleParser : IParser
    {
        public IExpression ParseExpression(string expression)
        {
            return new SimpleExpression(expression);
        }
    }
}
