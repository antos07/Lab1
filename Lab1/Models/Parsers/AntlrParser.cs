using Antlr4.Runtime;
using Lab1.Models.Expressions;
using Lab1.Parsers;
using Lab1.ANTLR4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Models.Parsers.antlr4;
using Lab1.Models.Tables;

namespace Lab1.Models.Parsers
{
    public class AntlrParser : IParser
    {
        public IExpression ParseExpression(string expression)
        {
            var inputStream = new AntlrInputStream(expression);

            var errorListener = new ErrorListener();

            var lexer = new ExpressionsLexer(inputStream);
            lexer.AddErrorListener(errorListener);

            var tokenStream = new CommonTokenStream(lexer);

            var parser = new ExpressionsParser(tokenStream);
            parser.AddErrorListener(errorListener);

            ExpressionsParser.ExpressionInCellContext tree = parser.expressionInCell();

            if (errorListener.Errors.Count > 0)
            {
                foreach (ParserError error in errorListener.Errors)
                {
                    MessageBox.Show($"{error.Message} -- {error.Token} -- {error.Line} -- {error.CharPositionInLine} -- {error.SuppressedException}");
                }
            }

            return new AntlrExpression(tree);
        }
    }
}
