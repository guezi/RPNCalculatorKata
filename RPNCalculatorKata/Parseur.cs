using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{


    public class Parseur
    {
        private IList<string> Lemes = new List<string>() { @"^\d+$", @"^\+$", @"^-$", @"^\*$", "^/$", @"^\^$" };
        private IList<Terme> Lexemes = new List<Terme>();
        public IList<string> Elements { get; set; }
        public string Texte { get; set; }
        public void Parser(string texte)
        {
            Texte = texte;
            Elements = texte.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool ValidateExpression()
        {
            foreach (var element in Elements)
            {
                if (Lemes.All(p => !Regex.IsMatch(element, p)))
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
            var stack = new Stack<IExpression>();
            foreach (var element in Elements)
            {
                var ele = FactoryTerme.Instance(element, stack);

            }
            if (stack.Count != 1)
            {
                throw new ArgumentException($"Expression not correct : {Texte?.Trim()}");
            }

            return stack.Pop();
        }
    }
}
