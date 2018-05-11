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
        readonly IDictionary<string, Func<double, double,double>> operatorDictionary = new Dictionary<string, Func<double, double,double>>(StringComparer.CurrentCultureIgnoreCase)
        {
            { "+",(p,k)=>p+k},
            { "-",(p,k)=>p-k},
            { "*",(p,k)=>p*k},
            { "/",(p,k)=>p/k},
            { "^",Math.Pow},
            { "Sin",(p,k)=>Math.Sin(p)},
            { "Cos",(p,k)=>Math.Cos(p)},

        };
        private readonly string _element;
        public TypeOpeator typeOp { get; set; }
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
        public double Evaluate()
        {
            var value1 = Exp1.Evaluate();
            var value2 = Exp2.Evaluate();
            if (operatorDictionary.TryGetValue(_element, out var ope))
            {
                return ope(value1,value2);
            }
            throw new EvaluateException();
        }

        public string Display()
        {
            return $"({Exp1.Display()}{_element}{Exp2.Display()})";
        }

        public IExpression Clone()
        {
            throw new NotImplementedException();
        }
    }
}
