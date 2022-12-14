using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class RationalModException : Exception
    {
        public int StartPos { get; }
        public int EndPos { get; }

        public RationalModException(int startPos, int endPos) : base()
        {
            StartPos = startPos;
            EndPos = endPos;
        }
    }
}
