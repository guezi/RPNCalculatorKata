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
            var map=new MappingLexeme();
            var factoryTerme = new FactoryTerme (map); 
            var parseur = new Parseur(factoryTerme);
            string expression="4 3 2 1 + + +";
            parseur.Parser(expression);
            var result = parseur.ValidateExpression();

            var value = parseur.BuildExpression().Evaluate;

            Console.WriteLine(parseur.Texte);
            foreach (var element in parseur.Elements    )
            {
                Console.WriteLine(element);
            }
           
            Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}
