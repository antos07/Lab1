﻿using Antlr4.Runtime.Misc;
using Lab1.ANTLR4;
using Lab1.Models.Tables;
using ExtendedNumerics;
using Antlr4.Runtime.Tree;
using Lab1.Models.Expressions.Exceptions;

namespace Lab1.Models.Parsers.antlr4
{
    public class Calculator : ExpressionsBaseVisitor<dynamic>
    {
        ITable _table;

        public Calculator(ITable table)
        {
            _table = table;
        }

        public override dynamic VisitExpressionInCell([NotNull] ExpressionsParser.ExpressionInCellContext context)
        {
            return Visit(context.booleanExpression());
        }


        #region boolExpression visitors
        public override dynamic VisitAndBoolExp([NotNull] ExpressionsParser.AndBoolExpContext context)
        {
            bool left = Visit(context.booleanExpression(0));
            bool right = Visit(context.booleanExpression(1));

            return left && right;
        }

        public override dynamic VisitCellIdBoolExp([NotNull] ExpressionsParser.CellIdBoolExpContext context)
        {
            string cellID = context.CELL_ID().GetText();

            try
            {
                return _table.GetCell(cellID).GetValue();
            }
            catch (ExpressionCalculationException)
            {
                throw new InvalidExpressionInReferencedCellException(cellID);
            }
        }

        public override dynamic VisitCompBoolExp([NotNull] ExpressionsParser.CompBoolExpContext context)
        {
            BigRational left = Visit(context.arithmeticExpression(0));
            BigRational right = Visit(context.arithmeticExpression(1));
            string comparisonOperator = context.COMPARISON_OPERATOR().GetText();

            switch (comparisonOperator)
            {
                case "=":
                    return left == right;
                case "<>":
                    return left != right;
                case ">=":
                    return left >= right;
                case "<=":
                    return left <= right;
                case "<":
                    return left < right;
                case ">":
                    return left > right;
                default:
                    throw new ApplicationException($"Unexpected operation '{comparisonOperator}'");
            }
        }

        public override dynamic VisitNotBoolExpr([NotNull] ExpressionsParser.NotBoolExprContext context)
        {
            return !Visit(context.booleanExpression());
        }

        public override dynamic VisitOrBoolExp([NotNull] ExpressionsParser.OrBoolExpContext context)
        {
            bool left = Visit(context.booleanExpression(0));
            bool right = Visit(context.booleanExpression(1));

            return left || right;
        }

        public override dynamic VisitParenthesisBoolExp([NotNull] ExpressionsParser.ParenthesisBoolExpContext context)
        {
            return Visit(context.booleanExpression());
        }



        #endregion

        #region arithmeticExpression

        public override dynamic VisitFunctionArExp([NotNull] ExpressionsParser.FunctionArExpContext context)
        {
            string function = context.FUNCTION().GetText();
            BigRational x = Visit(context.arithmeticExpression(0));
            BigRational y = Visit(context.arithmeticExpression(1));

            switch (function)
            {
                case "max":
                    return Max(x, y);
                case "min":
                    return Min(x, y);
                default:
                    throw new ApplicationException($"Unexpected function '{function}'");
            }
        }

        public override dynamic VisitModArExp([NotNull] ExpressionsParser.ModArExpContext context)
        {
            BigRational x = Visit(context.arithmeticExpression(0));
            BigRational y = Visit(context.arithmeticExpression(1));

            if (x.FractionalPart != 0 || y.FractionalPart != 0)
                throw new RationalModException(context.Start.StartIndex, context.Stop.StopIndex + 1);
            if (y.WholePart == 0)
                throw new ZeroDevisionInVisitorException(context.Start.StartIndex, context.Stop.StopIndex + 1);

            return new BigRational(x.WholePart % y.WholePart);
        }

        public override dynamic VisitMultDivArExp([NotNull] ExpressionsParser.MultDivArExpContext context)
        {
            BigRational x = Visit(context.arithmeticExpression(0));
            BigRational y = Visit(context.arithmeticExpression(1));

            if (context.MULTIPLY() != null)
                return x * y;
            if (y == 0)
                throw new ZeroDevisionInVisitorException(context.Start.StartIndex, context.Stop.StopIndex + 1);
            if (context.DIVIDE() != null)
                return x / y;
            else
                return new BigRational(x.WholePart / y.WholePart);
        }

        public override dynamic VisitPlusMinusArExp([NotNull] ExpressionsParser.PlusMinusArExpContext context)
        {
            BigRational x = Visit(context.arithmeticExpression(0));
            BigRational y = Visit(context.arithmeticExpression(1));

            if (context.PLUS() != null)
                return x + y;
            else
                return x - y;
        }

        public override dynamic VisitSignedNumericExp([NotNull] ExpressionsParser.SignedNumericExpContext context)
        {
            string sign = (context.PLUS() ?? context.MINUS()).GetText();
            string number = context.UNSIGNED_NUMBER().GetText();
            return BigRational.Parse(sign + number);
        }

        public override dynamic VisitUnsignedNumericArExp([NotNull] ExpressionsParser.UnsignedNumericArExpContext context)
        {
            string number = context.UNSIGNED_NUMBER().GetText();
            return BigRational.Parse(number);
        }

        public override dynamic VisitParenthesisArExp([NotNull] ExpressionsParser.ParenthesisArExpContext context)
        {
            return Visit(context.arithmeticExpression());
        }



        #endregion

        #region Math functions

        static private BigRational Max(BigRational x, BigRational y)
        {
            return x >= y ? x : y;
        }

        static private BigRational Min(BigRational x, BigRational y)
        {
            return x <= y ? x : y;
        }

        #endregion
    }
}
