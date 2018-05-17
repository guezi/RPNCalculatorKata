using System.Collections.Generic;
using System.Linq;

namespace RPNCalculatorKata.Operators.Arithmetique
{
    class Sum : AExpression
    {
        private const string Separator = "+";
        public Sum()  
        {
            Element = "Sum";
        }
        public override string DisplayName => "Sum";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.BI;
        public override double Evaluate => Expressions.Aggregate(0.0, (prod, next) => prod +next.Evaluate);// Expressions.Sum(p=>p.Evaluate);
        public override string Display => $"{DisplayName}({string.Join(Separator, Expressions.Select(p=>p.Display))})";
        public override IExpression Clone => new Sum();
        public override string RegExForm => "Sum";
        public override void SetUpExpression(string element, Stack<IExpression> stack)
        {
            var stackCount = stack.Count;
            for (int i = 0; i < stackCount; i++)
            {
                Expressions.Add(stack.Pop());
            }
        }
    }
}
