using Lab1.Models.Parsers.antlr4;
using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    public class AntlrExpression : IExpression
    {
        private ExpressionsParser.BooleanExpressionContext _tree;

        public AntlrExpression(ExpressionsParser.BooleanExpressionContext tree)
        {
            _tree = tree;
        }

        public bool Calculate(ITable forTable)
        {
            var calculator = new Calculator(forTable);
            return calculator.Visit(_tree);
        }
    }
}
