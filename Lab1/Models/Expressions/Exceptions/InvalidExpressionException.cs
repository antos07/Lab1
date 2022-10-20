using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions.Exceptions
{
    public class InvalidExpressionException : ExpressionCalculationException
    {
        public InvalidExpressionException(string message, IExpression expression, int startPos, int endPos) : base(message, expression, startPos, endPos)
        {
        }
    }
}
