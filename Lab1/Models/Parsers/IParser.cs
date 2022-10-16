﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Models.Expressions;

namespace Lab1.Parsers
{
    internal interface IParser
    {
        IExpression ParseExpression(string expression);
    }
}
