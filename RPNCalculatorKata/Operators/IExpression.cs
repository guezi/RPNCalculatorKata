using System.Collections.Generic;

namespace RPNCalculatorKata.Operators
{
    public interface IExpression
    {
        string DisplayName { get; }
        string Element { get; set; }
        TypeOpeator TypeOp { get; }
        IList<IExpression> Expressions { get; set; }
        double Evaluate { get; }
        string Display { get; }
        IExpression Clone { get; }
        string RegExForm { get; }
        void PopExpressionInStarck(string element, Stack<IExpression> starck);
    }
}
