using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
    class Sin : IExpression
    {
        public TypeOpeator typeOp
        {
            get => TypeOpeator.MONO;

        }

        private readonly string _element;

        public Sin(string element)
        {
            _element = element;
        }

        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public double Evaluate()
        {
            return Math.Sin(Exp1.Evaluate());
        }

        public string Display()
        {
            return $"{_element}({Exp1.Display()})";
        }

        public IExpression Clone()
        {
            return new Sin(_element);
        }
    }

}
