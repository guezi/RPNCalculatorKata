using System.Globalization;

namespace RPNCalculatorKata.Operators
{
    class Number : IExpression
    {
        public string DisplayName => Element.ToString(CultureInfo.InvariantCulture);

        public string Element { get; set; }
        public TypeOpeator typeOp => TypeOpeator.NONE;
        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
       
        public Number(string  value)
        {
            Element = value;
        }
        
        public double Evaluate()
        {
            double.TryParse(Element, out var val);
            return val;
        }

        public string Display()
        {
           return $"{DisplayName}";
        }

        public IExpression Clone()
        {
            return new Number("0") ;
        }
    }
}
