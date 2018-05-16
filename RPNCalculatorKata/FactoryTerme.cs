using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RPNCalculatorKata.Operators;
using RPNCalculatorKata.Operators.Trigonometrie;

namespace RPNCalculatorKata
{
    public   class FactoryTerme
    {
       public   readonly IDictionary<string, IExpression> MappingOperatorRegEx =
            new Dictionary<string, IExpression>(StringComparer.InvariantCultureIgnoreCase)
            {
                {@"\+", new Plus()},
                {"-", new Minus()},
                {@"\*", new Time()},
                {"/", new Divide()},
                {"\\^", new Power()},
                {"Sin", new Sin()},
                {"Cos", new Cos()},
                {@"^\d+(\.\d+)?$", new Number("0")},
            };

        public FactoryTerme():this(TypeGrammaire.PostFixe)
        {
           
        }

        public FactoryTerme(TypeGrammaire typeGrammaire)
        {
            GrammarType = typeGrammaire;
        }

        public TypeGrammaire GrammarType { get; set; } 

        private   IExpression Instance(string element, Stack<IExpression> stack)
        {
            IExpression elementTemp =null;
            foreach (var keyValuePair in MappingOperatorRegEx)
            {
                if (Regex.IsMatch(element, keyValuePair.Key, RegexOptions.IgnoreCase))
                {
                     elementTemp = keyValuePair.Value.Clone;
                    switch (elementTemp.TypeOp)
                    {
                        case TypeOpeator.PolyMorph when stack.Count == 1:
                            elementTemp = new Number("-" + stack.Pop().Element);
                            break;
                        case TypeOpeator.BI:
                        case TypeOpeator.PolyMorph:
                            elementTemp.Exp1 = stack.Pop();
                            elementTemp.Exp2 = stack.Pop();
                            break;
                        case TypeOpeator.MONO:
                            elementTemp.Exp1 = stack.Pop();
                            break;
                        default:
                            elementTemp.Element = element;
                            break;
                    }

                    stack.Push(elementTemp);
                   break;// elementTemp;
                }
            }
            return elementTemp;
            //  throw new ArgumentException($"Expression not correct : {element?.Trim()}");
        }

        public   IExpression BuildExpression(string expression,IList<string> elements) 
        {
            var stack = new Stack<IExpression>();
            elements = TransformeByGrammarTyep(elements);
            foreach (var element in elements)
            {
                var ele =  Instance(element, stack);
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
    }
}