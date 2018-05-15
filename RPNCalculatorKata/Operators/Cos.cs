using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
    class Cos : IExpression
    {
        public string DisplayName => "Cos";

        public TypeOpeator typeOp
        {
            get => TypeOpeator.MONO;

        }

        public string Element { get; set; }

        public Cos( )
        {
            Element = "Cos";
        }

        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }

        public double Evaluate()
        {
            return Math.Cos(Exp1.Evaluate());
        }

        public string Display()
        {
            return $"{DisplayName}({Exp1.Display()})";
        }

        public IExpression Clone()
        {
            return new Cos();
        }
    }
}
