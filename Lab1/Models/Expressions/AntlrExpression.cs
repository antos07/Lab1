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
        private ExpressionsParser.ExpressionInCellContext _tree;

        public AntlrExpression(ExpressionsParser.ExpressionInCellContext tree)
        {
            _tree = tree;
        }

        public bool Calculate(ITable forTable)
        {
            var calculator = new Calculator(forTable);
            try
            {
                return calculator.Visit(_tree);
            }
            catch (ZeroDevisionInVisitorException e)
            {
                throw new Exceptions.ZeroDevisionInExpressionException($"Zero division in '{ToString()}'",
                    this, e.StartPos, e.EndPos);
            }
            catch (RationalModException e)
            {
                throw new Exceptions.ModForNonintegersException($"Using mod with nonintegers '{ToString()}'",
                    this, e.StartPos, e.EndPos);
            }
            catch (InvalidExpressionInReferencedCellException e)
            {
                string exp = ToString();
                int startPos = exp.IndexOf(e.CellId);
                int endPos = startPos + e.CellId.Length;

                throw new Exceptions.ReferencedInvalidExpressionException($"Referncing invalid expression in {e.CellId}",
                    this, startPos, endPos, e.CellId);
            }
        }

        public string ToString()
        {
            return _tree.GetText();
        }
    }
}
