using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
    class Power : AExpression
    {
        public Power()
        {
            Element = "^";
        }
        public override string DisplayName => "^";
        public override TypeOpeator TypeOp => TypeOpeator.BI;
        public override double Evaluate => Math.Pow(Exp1.Evaluate, Exp2.Evaluate);
        public override string Display => $"({Exp1.Display}{DisplayName}{Exp2.Display})";
        public override IExpression Clone => new Power();
        public override string RegExForm  => "\\^";

    }
}
