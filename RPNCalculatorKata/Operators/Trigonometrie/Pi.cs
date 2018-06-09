using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators.Trigonometrie
{
    class Pi : AExpression
    {
        public Pi()
        {
            Element = "Pi";
        }
        public override string DisplayName => "Pi";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.Mono;
        public override double Evaluate => Math.PI;
        public override string Display => $"Pi";
        public override IExpression Clone => new Pi();
        public override string RegExForm => "Pi";
        public override void PopExpressionInStarck(string element, Stack<IExpression> stack)
        {
            
        }
    }
}
