using System.Collections.Generic;
using System.Linq;

namespace RPNCalculatorKata.Operators.Arithmetique
{
    class Prod: AExpression
    {
        private const string Separator = "*";
        public Prod()  
        {
            Element = "Prod";
        }
        public override string DisplayName => "Prod";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.BI;
        public override double Evaluate => Expressions.Aggregate(1.0,(prod,next) => prod*next.Evaluate);
        public override string Display => $"{DisplayName}({string.Join(Separator, Expressions.Select(p => p.Display))})";
        public override IExpression Clone => new Prod();
        public override string RegExForm => "Prod";
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
