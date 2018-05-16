using System;

namespace RPNCalculatorKata.Operators.Trigonometrie
{
    class Cos : AExpression
    {
        public Cos()
        {
            Element = "Cos";
        }
        public override string DisplayName => "Cos";

        public override TypeOpeator TypeOp { get; } = TypeOpeator.MONO;

      
        public override double Evaluate => Math.Cos(Exp1.Evaluate);

        public override string Display => $"{DisplayName}({Exp1.Display})";

        public override IExpression Clone => new Cos();
        public override string RegExForm => "Cos";

    }
}
