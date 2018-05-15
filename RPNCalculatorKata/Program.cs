using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var parseur = new Parseur(new FactoryTerme ());
            string expression="4 3 2 1 + + +";
            parseur.Parser(expression);
            var result = parseur.ValidateExpression();

            var value = parseur.GetExpression().Evaluate();

            Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}
