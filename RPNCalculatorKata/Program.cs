using System;

namespace RPNCalculatorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            IMappingLexeme map =new MappingLexeme();
            var factoryTerme = new FactoryTerme (map); 
            var parseur = new Parseur(factoryTerme);
            string expression="4 3 2 1 + + +";
            parseur.Parser(expression);
            parseur.ValidateExpression();

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
