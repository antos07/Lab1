using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ANTLR4
{
    public class CellReferencesFinder : ExpressionsBaseVisitor<object>
    {
        public List<string> CellReference { get; } = new List<string>();

        public override object VisitCellIdArExp([NotNull] ExpressionsParser.CellIdArExpContext context)
        {
            CellReference.Add(context.CELL_ID().GetText());
            return base.VisitCellIdArExp(context);
        }

        public override object VisitCellIdBoolExp([NotNull] ExpressionsParser.CellIdBoolExpContext context)
        {
            CellReference.Add(context.CELL_ID().GetText());
            return base.VisitCellIdBoolExp(context);
        }
    }
}
