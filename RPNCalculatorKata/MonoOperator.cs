using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
  public  class MonoOperator  
    {
        readonly IDictionary<string ,Func<double,double>> operatorDictionary= new Dictionary<string, Func<double, double>>(StringComparer.CurrentCultureIgnoreCase)
       {
           { "Sin",Math.Sin},
           { "Cos",Math.Cos}, 
       };
        private readonly string _element;
        public IExpression Exp1 { get; set; }
        public MonoOperator(string element) 
        {
            _element =element;
        }
        public double Evaluate()
        {
            if (operatorDictionary.TryGetValue(_element, out var ope))
            {
                var value1 = Exp1.Evaluate();
                return ope(value1);
            }
            throw new EvaluateException();
        }

        public string Display()
        {
            var ele = _element.Substring(0, 1).ToUpper() + _element.Substring(1).ToLower();
            return $"{ele}({Exp1.Display()})";
        }
    }
}
