using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class ErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        public List<ParserError> Errors { get; }

        public ErrorListener()
        {
            Errors = new List<ParserError>();
        }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Errors.Add(new ParserError(msg, offendingSymbol, line, charPositionInLine, e));
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Errors.Add(new ParserError(msg, null, line, charPositionInLine, e));
        }
    }
}
