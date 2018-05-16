using System;

namespace RPNCalculatorKata.Operators.Trigonometrie
{
    class Sin : AExpression
    {
        public Sin()
        {
            Element = "Sin";
        }
        public override string DisplayName => "Sin";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.MONO;
        public override double Evaluate => Math.Sin(Exp1.Evaluate);
        public override string Display => $"{DisplayName}({Exp1.Display})";
        public override IExpression Clone => new Sin();
        public override string RegExForm => "Sin";
    }
    
}
