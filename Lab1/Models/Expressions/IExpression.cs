﻿using Lab1.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    public interface IExpression
    {
        public HashSet<string> ReferencedCells { get; }

        public  string ToString();

        public object Calculate(ITable forTable);

        public void RenameReference(string oldCellId, string newCellId);
    }
}
