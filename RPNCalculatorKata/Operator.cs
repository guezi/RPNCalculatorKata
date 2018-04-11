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
        public int GetValue()
        {
            if ("+".Equals(_element.Trim()))
            {
                return Exp1.GetValue() + Exp2.GetValue();
            }
            if ("*".Equals(_element.Trim()))
            {
                return Exp1.GetValue() *Exp2.GetValue();
            }
            if ("-".Equals(_element.Trim()))
            {
                return Exp1.GetValue() -Exp2.GetValue();
            }
            if ("/".Equals(_element.Trim()))
            {
                return Exp1.GetValue()/ Exp2.GetValue();
            }
            throw new EvaluateException();
        }

        public string Display()
        {
            return $"({Exp1.Display()}{_element}{Exp2.Display()})";
        }
    }
}
