using System;
using NFluent;
using NUnit.Framework;
using RPNCalculatorKata;

namespace RPNCalculatorKataTests
{
    [TestFixture()]
    public class ParseurTests
    {

        private FactoryTerme _factoryTerme;
        private Parseur _parseur;
        [SetUp]
        public void Init()
        {
            _factoryTerme = new FactoryTerme();
            _parseur = new Parseur(_factoryTerme);
        }

        [TestCase("-")]
        [TestCase("+")]
        [TestCase("*")]
        [TestCase("/")]
        [TestCase("^")]
        [TestCase("Sin")]
        [TestCase("Cos")]
        [TestCase("125")]
        [TestCase("125 356")]
        [TestCase("125 ")]
        [TestCase("125.1 ")]
        public void When_Terme_Is_Correct_Then_ValidateExpression_True(string expression)
        {
            _parseur.Parser(expression);
            var result = _parseur.ValidateExpression();
            Check.That(result).IsTrue();
        }
        [TestCase("s")]
        [TestCase("x 356")]
        [TestCase("125.")]
        [TestCase(".1235")]
        public void When_Terme_Is_NotCorrect_Then_ValidateExpression_False(string expression)
        {
            _parseur.Parser(expression);
            var result = _parseur.ValidateExpression();
            Check.That(result).IsFalse();
        }
        [TestCase("s")]
        [TestCase("x 356")]
        [TestCase("125.")]
        [TestCase(".1235")]
        public void When_Terme_Is_Correct_Then_GetExpression_ThrowException(string expression)
        {
            _parseur.Parser(expression);
            var result = _parseur.ValidateExpression();
            Check.ThatCode(() => _parseur.GetExpression()).Throws<ArgumentException>();
        }

        [TestCase("123", "123")]
        [TestCase("1 2 +", "+")]
        [TestCase("1 2 *", "*")]
        [TestCase("1 2 -", "-")]
        [TestCase("1 2 /", "/")]
        [TestCase("1 2 ^", "^")]
        [TestCase(" 2 Sin", "Sin")]
        [TestCase(" 2 Cos", "Cos")]
        public void When_Terme_Is_Correct_Then_GetExpression_Correct(string expression, string expected)
        {
            _parseur.Parser(expression);
            var result = _parseur.GetExpression();
            Check.That(result.Element).Equals(expected);
        }


        [TestCase("1 2 +", 3, "(2+1)")]
        [TestCase("1 2 3 + +", 6, "((3+2)+1)")]
        [TestCase("1 2 3 4 + + +", 10, "(((4+3)+2)+1)")]
        public void Wheen_Terme_Is_Correct_Then_Plus_GetExpression_Correct(string expression, int result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);

        }
        [TestCase("1 -", -1, "-1")]
        [TestCase("1 2 -", 1, "(2-1)")]
        [TestCase("1 2 3 - -", 0, "((3-2)-1)")]
        [TestCase("1 2 3 4 - - -", -2, "(((4-3)-2)-1)")]
        public void Wheen_Terme_Is_Correct_Then_Minus_GetExpression_Correct(string expression, int result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);

        }
        [TestCase("1 2 *", 2, "(2*1)")]
        [TestCase("1 2 3 * *", 6, "((3*2)*1)")]
        [TestCase("1 2 3 4 * * *", 24, "(((4*3)*2)*1)")]
        public void Wheen_Terme_Is_Correct_Then_Time_GetExpression_Correct(string expression, int result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);

        }

        [TestCase("0 Sin", 0, "Sin(0)")]
        [TestCase("0 sin", 0, "Sin(0)")]
        [TestCase("3 sin", 3, "Sin(3)")]
        [TestCase("3.3 sin", 3.3, "Sin(3.3)")]
        public void Wheen_Terme_Is_Correct_Then_Sin_GetExpression_Correct(string expression, double result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            Check.That(Math.Sin(result)).Equals(value);
            Check.That(infixe).Equals(display);
        }
        [TestCase("0 Cos", 0, "Cos(0)")]
        [TestCase("1 cos", 1, "Cos(1)")]
        [TestCase("3 cos", 3, "Cos(3)")]
        [TestCase("3.3 cos", 3.3, "Cos(3.3)")]
        public void Wheen_Terme_Is_Correct_Then_Cos_GetExpression_Correct(string expression, double result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            var cos = Math.Cos(result);
            Check.That(cos).Equals(value);
            Check.That(infixe).Equals(display);
        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        [TestCase("1 2 +", 3, "(2+1)")]
        [TestCase("1 2 -", 1, "(2-1)")]
        [TestCase("1 2 *", 2, "(2*1)")]
        [TestCase("1 2 /", 2, "(2/1)")]
        [TestCase("3 2 ^", 8, "(2^3)")]
        [TestCase("3 2 ^", 8, "(2^3)")]
        [TestCase("3 2 ^", 8, "(2^3)")]
        public void ValidateExpressionTest1(string expression, int result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);

        }


        [TestCase("3 5 8 * 7 + *", 141, "((7+(8*5))*3)")]
        [TestCase("4 2 + 3 -", -3, "(3-(2+4))")]
        [TestCase("5 20 /", 4, "(20/5)")]
        [TestCase("2 3 ^", 9, "(3^2)")]
        [TestCase("2 2 3 ^ ^", 81, "((3^2)^2)")]
        [TestCase("3 3 3 ^ ^", 19683, "((3^3)^3)")]
        [TestCase("4 3 2 ^ ^", 4096, "((2^3)^4)")]
        public void ValidateExpressionTest2(string expression, int result, string infixe)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            var display = _parseur.GetExpression().Display();
            Check.That(result).Equals(value);
            Check.That(infixe).Equals(display);
        }

        [TestCase("1 2 s", -1, "(1-2)")]
        public void ValidateExpressionTest3(string expression, int result, string infixe)
        {
            _parseur.Parser(expression);
            Check.ThatCode(() => _parseur.GetExpression()).Throws<Exception>().WithMessage("Expression not correct : 1 2 s");
        }

        [TestCase("  2 +")]
        [TestCase("2 2")]
        public void ValidateExpressionTest4(string expression)
        {
            _parseur.Parser(expression);
            Check.ThatCode(() => _parseur.GetExpression()).Throws<Exception>();//.WithMessage($"Expression not correct : {expression.Trim()}");
        }

        [TestCase("2 2 3 ^ ^", 81)]
        [TestCase("3 3 3 ^ ^", 19683)]
        public void ValidateExpressionTest5(string expression, int result)
        {
            _parseur.Parser(expression);
            var value = _parseur.GetExpression().Evaluate();
            Check.That(result).Equals(value);
        }

       

    }
}