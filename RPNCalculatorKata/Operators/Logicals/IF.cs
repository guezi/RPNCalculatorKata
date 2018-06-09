using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators.Logicals
{
    class IF : AExpression
    {
        double value;
        public IF()
        {
            Element = "IF";
        }
        public override string DisplayName => "IF";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.Bi;
        public override double Evaluate {
            get {
                if(Expressions[0].Evaluate>= 0)
                {
                  return  Expressions[1].Evaluate;
                }
                else
                {
                    return Expressions[2].Evaluate;
                }
                 
            } }
      //  vlaue;// Exp1.Evaluate + Exp2.Evaluate;
        public override string Display => $"{DisplayName}[{Expressions[0].Display},{Expressions[1].Display},{Expressions[2].Display}]";
        public override IExpression Clone => new IF();
        public override string RegExForm => @"IF";
        public override void PopExpressionInStarck(string element, Stack<IExpression> stack)
        {
            Expressions.Add(stack.Pop());
            Expressions.Add(stack.Pop());
            Expressions.Add(stack.Pop());
            
        }

    }
    class LeftCrochet : AExpression
    {
        double value;
        public LeftCrochet()
        {
            Element = "[";
        }
        public override string DisplayName => "[";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.Bi;
        public override double Evaluate
        {
            get
            {
                if (Expressions[0].Evaluate >= 0)
                {
                    return Expressions[1].Evaluate;
                }
                else
                {
                    return Expressions[2].Evaluate;
                }

            }
        }
        //  vlaue;// Exp1.Evaluate + Exp2.Evaluate;
        public override string Display => $"{DisplayName}[{Expressions[0].Display}]";
        public override IExpression Clone => new LeftCrochet();
        public override string RegExForm => @"\[";
        public override void PopExpressionInStarck(string element, Stack<IExpression> stack)
        {
            Expressions.Add(stack.Pop());          

        }

        class RightCrochet : AExpression
        {
            double value;
            public RightCrochet()
            {
                Element = "]";
            }
            public override string DisplayName => "]";
            public override TypeOpeator TypeOp { get; } = TypeOpeator.Bi;
            public override double Evaluate
            {
                get
                {
                    if (Expressions[0].Evaluate >= 0)
                    {
                        return Expressions[1].Evaluate;
                    }
                    else
                    {
                        return Expressions[2].Evaluate;
                    }
                }
            }
            //  vlaue;// Exp1.Evaluate + Exp2.Evaluate;
            public override string Display => $"{DisplayName}[{Expressions[0].Display},{Expressions[1].Display},{Expressions[2].Display}]";
            public override IExpression Clone => new RightCrochet();
            public override string RegExForm => @"\]";
            public override void PopExpressionInStarck(string element, Stack<IExpression> stack)
            {
                Expressions.Add(stack.Pop());             

            }

        }
    }
}
