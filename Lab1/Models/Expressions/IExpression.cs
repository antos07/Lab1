using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    internal interface IExpression
    {
        string ToString();

        string Calculate();
    }
}
