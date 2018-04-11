using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    public interface IExpression
    {
        int GetValue();
        string Display();

    }
}
