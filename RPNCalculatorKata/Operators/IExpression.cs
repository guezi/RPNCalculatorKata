using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    public interface IExpression 
    {
        string DisplayName { get; }
        string Element { get; set; }
        TypeOpeator typeOp {  get; } 

        IExpression Exp1 { get; set; }
          IExpression Exp2 { get; set; }
        double Evaluate(); 
        string Display();
        IExpression Clone();
    }
}
