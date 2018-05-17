using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using RPNCalculatorKata.Operators;

namespace RPNCalculatorKata
{
   public class MappingLexeme
    {
        private List<IExpression> _listOfRegExLeme;
        public MappingLexeme()
        {
             _listOfRegExLeme = GetType().Assembly.GetTypes()
                .Where(p => p.GetInterface(typeof(IExpression).Name, true) != null && !p.IsAbstract)
                .Select(p => Activator.CreateInstance(p, null))
                .Cast<IExpression>().ToList();
        }
        public IList<string> GetLexemes()
        {
            List<string> listOfRegExLeme = _listOfRegExLeme.Select(p => p.RegExForm).ToList();
            return listOfRegExLeme;
        }

        public IDictionary<string, IExpression> GetMappingRegExExpression()
        {
           Dictionary<string, IExpression> mappingOperatorRegEx = _listOfRegExLeme.ToDictionary(p => p.RegExForm);
            return mappingOperatorRegEx;
        }
    }
}
