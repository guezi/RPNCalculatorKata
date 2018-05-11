using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    class Number : IExpression
    {
        public int Value { get; set; }
        public Number(string  value)
        {
            int.TryParse(value, out var val);
            Value = val;
        }
        public Number(int value)
        {
            Value = value;
        }
        public int Evaluate()
        {
            return Value;
        }

        public string Display()
        {
           return $"{Value}";
        }
    }
}
