using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RPNCalculatorKata.Operators;

namespace RPNCalculatorKata
{
    public class FactoryTerme
    {
        static IDictionary<string, IExpression> operatorDictionary =
            new Dictionary<string, IExpression>(StringComparer.CurrentCultureIgnoreCase)
            {
                {"+", new Plus("+")},
                {"-", new Minus("-")},
                {"*", new Time("*")}, 
                {"/", new Divide("/")},
                {"^", new Power("^")},
                {"Sin", new Sin("Sin")},
                {"Cos", new Plus("+")},
            };

        public static IExpression Instance(string element, Stack<IExpression> stack)
        {
            if (operatorDictionary.TryGetValue(element, out var elem))
            {
                var elem1 = elem.Clone();
                if (elem1.typeOp == TypeOpeator.BI)
                {
                    elem1.Exp1 = stack.Pop();
                    elem1.Exp2 = stack.Pop();
                }
                else
                {
                    elem1.Exp1 = stack.Pop();
                }
                
                stack.Push(elem1);
                return elem1;
            }

            if (Regex.IsMatch(element, @"^\d+$"))
            {
                var ele = new Number(element);
                stack.Push(ele);
                return ele;
            }
            if (Regex.IsMatch(element, @"^-$") && (stack.Count == 1))
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
            if (Regex.IsMatch(element, @"^Sin$", RegexOptions.IgnoreCase))
            {
                var ele = new Operator(element);
                ele.Exp1 = stack.Pop();
                ele.Exp2 = new Number(-1);
                stack.Push(ele);

                return ele;
            }

            throw new ArgumentException($"Expression not correct : {element?.Trim()}");
        }
    }
}