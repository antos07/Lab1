using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class WrongValueTypeException : Exception
    {
        public int StartPos { get; }
        public int EndPos { get; }

        public Type ExpectedType { get; }
        
        public Type ActualType { get; }

        public WrongValueTypeException(int startPos, int endPos, Type expectedType, Type actualType) : base()
        {
            StartPos = startPos;
            EndPos = endPos;
            ExpectedType = expectedType;
            ActualType = actualType;
        }
    }
}
