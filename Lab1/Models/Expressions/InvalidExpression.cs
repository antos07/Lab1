using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    public class InvalidExpression : TextExpression
    {
        public InvalidExpression(string value) : base(value)
        {
        }

        public override bool Calculate(ITable forTable)
        {
            throw new Exceptions.InvalidExpressionException($"Trying to call invalid expression '{ToString()}'",
                this, 0, ToString().Length);
        }
    }
}
