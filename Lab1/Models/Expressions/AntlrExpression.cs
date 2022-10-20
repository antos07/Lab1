using Lab1.ANTLR4;
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
        private ExpressionsParser.ExpressionInCellContext? _tree;
        private string? _textRepresentation;
        private string? _errorDescription;

        /// <summary>
        /// Construcrtor for a valid expression.
        /// </summary>
        /// <param name="tree">AST for this expression</param>
        public AntlrExpression(ExpressionsParser.ExpressionInCellContext tree)
        {
            _tree = tree;
        }

        /// <summary>
        /// Construcor for invalid expression.
        /// </summary>
        /// <param name="textRepresentation">Text representation of the expression</param>
        /// <param name="errorDescription">Error description</param>
        public AntlrExpression(string textRepresentation, string errorDescription)
        {
            _textRepresentation = textRepresentation;
            _errorDescription = errorDescription;
        }

        public bool Calculate(ITable forTable)
        {
            var calculator = new Calculator(forTable);
            return calculator.Visit(_tree);
        }

        public string ToString()
        {
            return _tree.GetText();
        }
    }
}
