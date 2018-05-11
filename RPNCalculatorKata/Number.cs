using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    class Number : IExpression
    {
        public TypeOpeator typeOp
        {
            get => TypeOpeator.NONE;

        }
        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public double Value { get; set; }
        public Number(string  value)
        {
            double.TryParse(value, out var val);
            Value = val;
        }
        public Number(int value)
        {
            Value = value;
        }
        public double Evaluate()
        {
            return Value;
        }

        public string Display()
        {
           return $"{Value}";
        }

        public IExpression Clone()
        {
            throw new NotImplementedException();
        }
    }
}
