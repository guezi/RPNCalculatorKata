using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
   public class FactoryTerme
    {

        public static  IExpression Instance(string element, Stack<IExpression> stack)
        {
            if (Regex.IsMatch(element, @"^\d+$"))
            {
              
                var ele = new Number(element);
                stack.Push(ele);
                return ele;
            }
            if (Regex.IsMatch(element, @"^-$" ) && (stack.Count==1))
            {
                var ele = new Operator("*");
                ele.Exp1 = new Number(-1);
                ele.Exp2 = stack.Pop();
                stack.Push(ele);
                return ele;
            }
            if (Regex.IsMatch(element, @"^\+$|^-$|^\*$|^\^$|^/$"))
            {
                if (stack.Count < 2)
                {
                    throw new ArgumentException($"Expression not correct : {element?.Trim()}");
                }

                var ele = new Operator(element);
                ele.Exp1 = stack.Pop();
                ele.Exp2 = stack.Pop();
                stack.Push(ele);

                return ele;
            }
                throw new ArgumentException($"Expression not correct : {element?.Trim()}");
          

        }

    }
}
