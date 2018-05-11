using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    class Operator : IExpression
    {
        private readonly string _element;
        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }

        public Operator(string element)
        {
            _element = element;
        }
        public Operator(IExpression exp1, IExpression exp2)
        {
            Exp1 = exp1;
            Exp2 = exp2;
        }
        public int Evaluate()
        {
            var value1 = Exp1.Evaluate();
            var value2 = Exp2.Evaluate();
            if ("+".Equals(_element.Trim()))
            {
                return value1 + value2;
            }
            if ("*".Equals(_element.Trim()))
            {
                return value1 *value2;
            }
            if ("-".Equals(_element.Trim()))
            {
                return value1 -value2;
            }
            if ("/".Equals(_element.Trim()))
            {
                return value1/ value2;
            }
            if ("^".Equals(_element.Trim()))
            {
                return (int) Math.Pow(value1 , value2);
            }
            throw new EvaluateException();
        }

        public string Display()
        {
            return $"({Exp1.Display()}{_element}{Exp2.Display()})";
        }
    }
}
