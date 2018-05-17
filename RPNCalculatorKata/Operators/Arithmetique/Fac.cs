using System.Collections.Generic;
using System.Linq;

namespace RPNCalculatorKata.Operators.Arithmetique
{
    class Fac : AExpression
    {
        public Fac()
        {
            Element = "Fac";
        }
        public override string DisplayName => "!";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.BI;
        public override double Evaluate => Enumerable.Range(1, (int)Expressions[0].Evaluate).Aggregate((prod, next) => prod * next);
        public override string Display => $"({Expressions[0].Display}){DisplayName}";
        public override IExpression Clone => new Fac();
        public override string RegExForm => "!";
        public override void SetUpExpression(string element, Stack<IExpression> stack)
        {
            Expressions.Add(stack.Pop());

        }
    }

}
