using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions.Exceptions
{
    public class ExpressionCalculationException : Exception
    {
        IExpression Expression { get; }
        int StartPos { get;}
        int EndPos { get;}

        public ExpressionCalculationException(string message, IExpression expression, int startPos, int endPos) : base(message)
        {
            Expression = expression;
            StartPos = startPos;
            EndPos = endPos;
        }
    }
}
