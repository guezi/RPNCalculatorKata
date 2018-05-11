using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
    class Power : IExpression
    {
        public TypeOpeator typeOp
        {
            get => TypeOpeator.BI;

        }

        private readonly string _element;

        public Power(string element)
        {
            _element = element;
        }

        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public double Evaluate()
        {
            var d1 = Exp2.Evaluate();
            var d = Exp1.Evaluate();
           
            return Math.Pow(d ,d1);
        }

        public string Display()
        {
            return $"({Exp1.Display()}{_element}{Exp2.Display()})";
        }

        public IExpression Clone()
        {
            return new  Power(_element);
        }
    }
}
