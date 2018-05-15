using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    class LexemeIEqualityComparer: IEqualityComparer<string>
    {
        public bool Equals(string chaines, string chaine2)
        {
            if (chaines == null || chaine2 == null) return false;
            return Regex.IsMatch(chaines,"\\"+chaine2,RegexOptions.IgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            //@"^\*$"
            var hashCode = obj.ToUpperInvariant().GetHashCode();
            return hashCode;
        }
    }
}
