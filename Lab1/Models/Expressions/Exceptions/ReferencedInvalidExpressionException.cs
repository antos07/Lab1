using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions.Exceptions
{
    public class ReferencedInvalidExpressionException : ExpressionCalculationException
    {
        public string CellId { get; }

        public ReferencedInvalidExpressionException(string message, IExpression expression, int startPos, int endPos,
            string cellId) : base(message, expression, startPos, endPos)
        {
            CellId = cellId;
        }
    }
}
