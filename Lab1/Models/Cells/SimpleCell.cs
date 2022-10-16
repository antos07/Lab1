using Lab1.Models.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Cells
{
    public class SimpleCell : ICell
    {
        private IExpression? _expression;

        public IExpression? Expression { get => _expression; set => _expression = value; }

        public string Value => _expression != null ? _expression.Calculate() : String.Empty;
    }
}
