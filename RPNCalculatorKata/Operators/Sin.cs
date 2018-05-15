using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
    class Sin : IExpression
    {
        public string DisplayName => "Sin";
        public TypeOpeator typeOp
        {
            get => TypeOpeator.MONO;

        }

        public string Element { get; set; }

        public Sin( )
        {
            Element = "Sin";
        }

        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public double Evaluate()
        {
            return Math.Sin(Exp1.Evaluate());
        }

        public string Display()
        {
            return $"{DisplayName}({Exp1.Display()})";
        }

        public IExpression Clone()
        {
            return new Sin();
        }
    }

}
