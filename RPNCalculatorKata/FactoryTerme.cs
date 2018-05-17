using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RPNCalculatorKata.Operators;
using RPNCalculatorKata.Operators.Arithmetique;
using RPNCalculatorKata.Operators.Trigonometrie;

namespace RPNCalculatorKata
{
    public class FactoryTerme
    {
        public MappingLexeme MappingLexemes;
        private TypeGrammaire GrammarType { get; set; }

        public FactoryTerme(MappingLexeme mappingLexemes, TypeGrammaire typeGrammaire = TypeGrammaire.PostFixe)
        {
            MappingLexemes = mappingLexemes;
            GrammarType = typeGrammaire;
        }
        private void Instance(string element, Stack<IExpression> stack)
        {
            foreach (var keyValuePair in MappingLexemes.GetMappingRegExExpression())
            {
                if (Regex.IsMatch(element, keyValuePair.Key, RegexOptions.IgnoreCase))
                {
                    var elementTemp = keyValuePair.Value.Clone;
                    elementTemp.SetUpExpression(element, stack);
                    stack.Push(elementTemp);
                    break;
                }
            }
        }
        public IExpression BuildExpression(string expression, IList<string> elements)
        {
            var stack = new Stack<IExpression>();
            elements = TransformeByGrammarTyep(elements);
            foreach (var element in elements)
            {
                Instance(element, stack);
            }
            if (stack.Count != 1)
            {
                throw new ArgumentException($"Expression not correct : {expression?.Trim()}");
            }
            return stack.Pop();
        }
        private IList<string> TransformeByGrammarTyep(IList<string> elements)
        {
            if (GrammarType == TypeGrammaire.Prefixe)
            {
                return elements.Reverse().ToList();
            }
            return elements;
        }
        public IList<string> GetLexemes()
        {

            return MappingLexemes.GetLexemes();
        }
        public IDictionary<string, IExpression> GetMappingRegExExpression()
        {
            return MappingLexemes.GetMappingRegExExpression();
        }
    }
}