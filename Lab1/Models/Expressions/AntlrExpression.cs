﻿using ExtendedNumerics;
using Lab1.ANTLR4;
using Lab1.Models.Parsers.antlr4;
using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    public class AntlrExpression : IExpression
    {
        private ExpressionsParser.ExpressionInCellContext _tree;
        private bool _calculating = false;
        private string _textRepresentation;

        public AntlrExpression(ExpressionsParser.ExpressionInCellContext tree, string textRepresentation)
        {
            _tree = tree;
            _textRepresentation = textRepresentation;

            ReferencedCells = FindCellReferences();
        }

        public HashSet<string> ReferencedCells { get; }

        public virtual object Calculate(ITable forTable)
        {
            if (_calculating)
                throw new Exceptions.InfiniteRecursionException($"Expression '{ToString()}' includes infinite recursion",
                    this, 0, ToString().Length);
            var calculator = new Calculator(forTable);
            _calculating = true;
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
            catch (WrongValueTypeException e)
            {
                throw new Exceptions.WrongTypeException($"Operand has unexpected type in '{ToString()}'",
                    this, e.StartPos, e.EndPos, e.ExpectedType, e.ActualType);
            }
            finally
            {
                _calculating = false;
            }
        }

        public virtual string ToString()
        {
            return _textRepresentation;
        }

        private HashSet<string> FindCellReferences()
        {
            var finder = new CellReferencesFinder();
            finder.Visit(_tree);

            return finder.CellReference;
        }
    }
}
