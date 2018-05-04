using NUnit.Framework;
using RPNCalculatorKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;

namespace RPNCalculatorKata.Tests
{
    [TestFixture()]
    public class ParseurTests
    {
        [TestCase("125")]
        [TestCase("125 356")]
        [TestCase("125 ")]
        [TestCase("+")]
        [TestCase("*")]
        [TestCase("/")]
        public void ValidateExpressionTest(string expression)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            var result = parseur.ValidateExpression();
            Check.That(result).IsTrue();
        }
        [TestCase("s")]
        [TestCase("x 356")]
        public void ValidateExpressionTest_false(string expression)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            var result = parseur.ValidateExpression();
            Check.That(result).IsFalse();
        }
        [TestCase("125", 125, "125")]
        [TestCase("1 2 +", 3, "(2+1)")]
        [TestCase("1 2 *", 2, "(2*1)")]
        [TestCase("1 2 -", 1, "(2-1)")]
        [TestCase("5 -", -5, "(-1*5)")]
        public void ValidateExpressionTest1(string expression, int result, string infixe)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            var value = parseur.GetExpression().GetValue();
            var display = parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);

        }
        [TestCase("3 5 8 * 7 + *", 141, "((7+(8*5))*3)")]
        [TestCase("4 2 + 3 -", -3, "(3-(2+4))")]
        [TestCase("5 20 /", 4, "(20/5)")]
        [TestCase("2 2 3 ^ ^", 81, "((3^2)^2)")]
        [TestCase("3 3 3 ^ ^", 19683, "((3^3)^3)")]
        [TestCase("4 3 2 ^ ^", 4096, "((2^3)^4)")]
        public void ValidateExpressionTest2(string expression, int result, string infixe)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            var value = parseur.GetExpression().GetValue();
            var display = parseur.GetExpression().Display();
            Check.That(result).Equals(value); 
            Check.That(infixe).Equals(display);
        }

       [TestCase("1 2 s", -1, "(1-2)")]
        public void ValidateExpressionTest3(string expression, int result, string infixe)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
          Check.ThatCode(()=> parseur.GetExpression()).Throws<Exception>().WithMessage("Expression not correct : 1 2 s") ;
        }

        [TestCase("  2 +")]
        [TestCase("2 2")]
        public void ValidateExpressionTest4(string expression)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            Check.ThatCode(() => parseur.GetExpression()).Throws<Exception>();//.WithMessage($"Expression not correct : {expression.Trim()}");
        }


        [TestCase("2 2 3 ^ ^", 81)]
        [TestCase("3 3 3 ^ ^", 19683)]

        public void ValidateExpressionTest5(string expression, int result )
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            var value = parseur.GetExpression().GetValue();
            Check.That(result).Equals(value);
        }

        [TestCase("1 2 - -", -1, "(-1*(2-1))")]
        public void ValidateExpressionTest10001(string expression, int result, string infixe)
        {
            var parseur = new Parseur();
            parseur.Parser(expression);
            var value = parseur.GetExpression().GetValue();
            var display = parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);

        }
    }
}