using System.Collections.Generic;

namespace RPNCalculatorKata.Operators.Arithmetique
{
    public class Minus : AExpression
    {
        public Minus()  
        {
            Element = "-";
        }
        public override string DisplayName => "-";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.PolyMorph;
        public override double Evaluate => Expressions[0].Evaluate - Expressions[1].Evaluate;
        public override string Display => $"({Expressions[0].Display}{DisplayName}{Expressions[1].Display})";
        public override IExpression Clone => new Minus();
        public override string RegExForm  => "-";
        public override void SetUpExpression(string element, Stack<IExpression> stack)
        {
            Expressions.Add(stack.Pop());
            Expressions.Add(stack.Pop());
        }

    }
}
