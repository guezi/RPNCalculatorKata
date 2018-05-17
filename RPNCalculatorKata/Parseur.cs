using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RPNCalculatorKata.Operators;

namespace RPNCalculatorKata
{
    public class Parseur
    {
        public IList<string> Elements { get; set; }
        public string Texte { get; set; }
        private readonly FactoryTerme _factoryTerme;
        public Parseur(FactoryTerme factoryTerme)
        {
            _factoryTerme= factoryTerme;
        }
        public void Parser(string texte)
        {
            Texte = texte;
            var separator = new string[] { " " };
            Elements = texte.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool ValidateExpression()
        {
            var listOfRegExLeme = _factoryTerme.GetLexemes();
            foreach (var element in Elements)
            {
                if (listOfRegExLeme.All(p => !Regex.IsMatch(element, p, RegexOptions.IgnoreCase)))
                {
                    return false;
                }
            }
            return true;
        }

        public IExpression BuildExpression()
        {
            if (!ValidateExpression())
            {
                throw new ArgumentException($"Expression not correct : {Texte}");
            }
            return _factoryTerme.BuildExpression(Texte, Elements);
        }
    }
}
