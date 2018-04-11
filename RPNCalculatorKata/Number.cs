﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    class Number : IExpression
    {
        public int Value { get; set; }
        public Number(int value)
        {
            Value = value;
        }
        public int GetValue()
        {
            return Value;
        }

        public string Display()
        {
           return $"{Value}";
        }
    }
}