using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    public interface IExpression
    {
        string ToString();

        bool Calculate(ITable forTable);

        bool IsValid(ITable forTable);
    }
}
