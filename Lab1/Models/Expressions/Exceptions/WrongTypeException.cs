using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions.Exceptions
{
    internal class WrongTypeException : ExpressionCalculationException
    {
        public Type ExpectedType { get; }
        public Type ActualType { get; }

        public WrongTypeException(string message, IExpression expression, int startPos, int endPos, Type expectedType, Type actualType) : base(message, expression, startPos, endPos)
        {
            ExpectedType = expectedType;
            ActualType = actualType;
        }
    }
}
