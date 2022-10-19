using Lab1.Models.Expressions;
using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Cells
{
    public class SimpleCell : ICell
    {
        private readonly ITable _table;

        private IExpression? _expression;

        public IExpression? Expression { get => _expression; set => _expression = value; }

        public bool Value => _expression != null ? _expression.Calculate(_table) : false;

        public SimpleCell(ITable table)
        {
            _table = table;
        }
    }
}
