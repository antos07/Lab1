using Lab1.Models.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Cells
{
    public interface ICell
    {
        public IExpression? Expression { get; set; }
        public bool GetValue();
    }
}
