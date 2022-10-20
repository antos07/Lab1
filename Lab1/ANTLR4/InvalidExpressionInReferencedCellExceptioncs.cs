using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class InvalidExpressionInReferencedCellException: Exception
    {
        public string CellId { get; }

        public InvalidExpressionInReferencedCellException(string cellID)
        {
            CellId = cellID;
        }
    }
}
