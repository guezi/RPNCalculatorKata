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
            Elements = texte.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool ValidateExpression()
        {
            foreach (var element in Elements)
            {
                if (_factoryTerme.MappingOperatorRegEx.Keys.All(p => !Regex.IsMatch(element, p,RegexOptions.IgnoreCase)))
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
            return _factoryTerme.GetExpression(Texte, Elements);
        }
    }
}
