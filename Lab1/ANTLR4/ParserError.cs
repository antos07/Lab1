using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class ParserError
    {
        public string Message { get; }

        public IToken? Token { get; }

        public int Line { get; }

        public int CharPositionInLine { get; }

        public Exception SuppressedException { get; }
             

        public ParserError(string message, IToken? token, int line, int charPositionInLine, Exception suppressedException)
        {
            Message = message;
            Token = token;
            Line = line;
            CharPositionInLine = charPositionInLine;
            SuppressedException = suppressedException;
        }
    }
}
