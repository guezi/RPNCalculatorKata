namespace RPNCalculatorKata.Operators
{
    public abstract class AExpression : IExpression
    {
        public abstract string DisplayName { get; }
        public string Element { get; set; }
        public abstract TypeOpeator TypeOp { get; }
        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public abstract double Evaluate { get; }
        public abstract string Display { get; }
        public abstract IExpression Clone { get; }
        public abstract string RegExForm { get; }

    }
}