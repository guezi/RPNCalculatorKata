using System;
using System.Collections.Generic;

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
        public override double Evaluate => Math.Sin(Expressions[0].Evaluate);
        public override string Display => $"{DisplayName}({Expressions[0].Display})";
        public override IExpression Clone => new Sin();
        public override string RegExForm => "Sin";
        public override void SetUpExpression(string element, Stack<IExpression> stack)
        {
            Expressions.Add(stack.Pop());
        }
    }
    
}
