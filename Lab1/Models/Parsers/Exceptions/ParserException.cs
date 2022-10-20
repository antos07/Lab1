using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Parsers.Exceptions
{
    public class ParserException : Exception
    {
        public ParserException(string message) : base(message)
        { }
    }
}
