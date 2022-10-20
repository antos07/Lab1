using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions.Exceptions
{
    public class ExpressionCalculationException : Exception
    {
        public IExpression Expression { get; }
        public int StartPos { get;}
        public int EndPos { get;}

        public ExpressionCalculationException(string message, IExpression expression, int startPos, int endPos) : base(message)
        {
            Expression = expression;
            StartPos = startPos;
            EndPos = endPos;
        }
    }
}
