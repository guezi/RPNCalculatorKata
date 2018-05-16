namespace RPNCalculatorKata.Operators
{
    public interface IExpression
    {
        string DisplayName { get; }
        string Element { get; set; }
        TypeOpeator TypeOp { get; }
        IExpression Exp1 { get; set; }
        IExpression Exp2 { get; set; }
        double Evaluate { get; }
        string Display { get; }
        IExpression Clone { get; }
        string RegExForm { get; }
    }
}
