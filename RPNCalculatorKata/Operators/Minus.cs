using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
    public class Minus : IExpression
    {
        public string DisplayName => "-";

        public TypeOpeator typeOp
        {
            get => TypeOpeator.PolyMorph;

        }

        public string Element { get; set; }

        public Minus()
        {
            Element = "-";
        }

        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public double Evaluate()
        {
            return Exp1.Evaluate()- Exp2.Evaluate();
        }

        public string Display()
        {
            return $"({Exp1.Display()}{DisplayName}{Exp2.Display()})";
        }

        public IExpression Clone()
        {
            return new Minus();
        }
    }
}
