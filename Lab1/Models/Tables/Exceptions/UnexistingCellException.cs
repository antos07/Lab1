using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Tables.Exceptions
{
    public class UnexistingCellException : Exception
    {
        public string CellId { get; }

        public UnexistingCellException(string cellId)
        {
            CellId = cellId;
        }
    }
}
