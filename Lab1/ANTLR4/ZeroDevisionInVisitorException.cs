﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class ZeroDevisionInVisitorException : Exception
    {
        int StartPos { get; }
        int EndPos { get; }

        public ZeroDevisionInVisitorException(int startPos, int endPos) : base()
        {
            StartPos = startPos;
            EndPos = endPos;
        }
    }
}
