using System;
using System.Collections.Generic;

namespace RPNCalculatorKata.Operators.Trigonometrie
{
    class Cos : AExpression
    {
        public Cos() 
        {
            Element = "Cos";
        }
        public override string DisplayName => "Cos";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.Mono;
        public override double Evaluate => Math.Cos(Expressions[0].Evaluate);
        public override string Display => $"{DisplayName}({Expressions[0].Display})";
        public override IExpression Clone => new Cos();
        public override string RegExForm => "Cos";
        public override void PopExpressionInStarck(string element, Stack<IExpression> stack)
        {
            Expressions.Add(stack.Pop());
        }
    }
}
