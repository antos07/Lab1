﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Expressions
{
    internal class SimpleExpression : IExpression
    {
        private readonly string _value;

        public SimpleExpression(string value)
        {
            _value = value;
        }
        
        public string Calculate()
        {
            return _value;
        }

        override public string ToString()
        {
            return _value;
        }
    }
}
