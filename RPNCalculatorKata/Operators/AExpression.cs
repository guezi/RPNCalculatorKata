using System.Collections.Generic;

namespace RPNCalculatorKata.Operators
{
    public abstract class AExpression : IExpression
    {
        public AExpression()
        {
            Expressions=new List<IExpression>();
                
        }
        public abstract string DisplayName { get; }
        public string Element { get; set; }
        public abstract TypeOpeator TypeOp { get; }
        public IList<IExpression> Expressions { get; set; }
        public abstract double Evaluate { get; }
        public abstract string Display { get; }
        public abstract IExpression Clone { get; }
        public abstract string RegExForm { get; }
        public abstract void PopExpressionInStarck(string element, Stack<IExpression> stack);

    }
}