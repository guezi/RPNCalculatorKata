using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
  public  class Parseur
  {
      private IList<string> Lemes=new List<string>(){ @"^\d+$",@"^\+$",@"^-$",@"^\*$","^/$" };
      public IList<string> Elements { get; set; }
        public string Texte { get; set; }
        public void Parser(string texte)
        {
            Texte = texte;
              Elements = texte.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
        }

      public  bool ValidateExpression()
      {
          foreach (var element in Elements)
          {
              if (Lemes.All(p =>! Regex.IsMatch(element, p)))
              {
                  return false;
              }
          }
          return true;
      }

        public IExpression GetExpression()
        {
            if (!ValidateExpression())
            {
                throw new ArgumentException($"Expression not correct : {Texte}");
            }
            var stack=new Stack<IExpression>();
            foreach (var element in Elements)
            {
                if (Regex.IsMatch(element, @"^\d+$"))
                {
                    int.TryParse(element, out var val);
                  var ele=new Number(val);
                    stack.Push(ele);
                    continue;
                }
              
                if (Regex.IsMatch(element, @"^\+$|^\*$|^/$"))
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException($"Expression not correct : {Texte?.Trim()}");
                    }
                    
                    var ele = new Operator(element)
                    {
                        Exp2 = stack.Pop(),
                        Exp1 = stack.Pop()
                    };
                    stack.Push(ele);
                }
                  if (Regex.IsMatch(element, @"^-$"))
                {
                    if (stack.Count ==1)
                    {
                        var ele = new Operator("*")
                        {
                            Exp2 = stack.Pop(),
                            Exp1 = new Number(-1)
                        };

                        stack.Push(ele);
                        // throw new ArgumentException($"Expression not correct : {Texte?.Trim()}");
                    }
                    if (stack.Count == 2)
                    {
                        var ele = new Operator(element)
                        {
                            Exp2 = stack.Pop(),
                            Exp1 = stack.Pop()
                        };
                        stack.Push(ele); 
                        // throw new ArgumentException($"Expression not correct : {Texte?.Trim()}");
                    }


                }
            }
            if (stack.Count != 1)
            {
                throw new ArgumentException($"Expression not correct : {Texte?.Trim()}");
            }
           
            return stack.Pop();
        }
    }
}
