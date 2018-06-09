using System.Collections.Generic;
using RPNCalculatorKata.Operators;

namespace RPNCalculatorKata
{
    public interface IMappingLexeme
    {
        IList<string> GetLexemes();
        IDictionary<string, IExpression> GetMappingRegExExpression();
    }
}