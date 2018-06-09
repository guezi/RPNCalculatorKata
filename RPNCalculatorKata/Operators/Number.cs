﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace RPNCalculatorKata.Operators
{
    class Number : AExpression
    {
        public Number():this("0")
        {
            
        }
        public Number(string value)
        {
            Element = value;
        }
        public override string DisplayName => Element.ToString(CultureInfo.InvariantCulture);
        public override TypeOpeator TypeOp => TypeOpeator.None;
      

        public override double Evaluate
        {
            get
            {
                double val;
              var boo=  Double.TryParse(Element, NumberStyles.Number, CultureInfo.InvariantCulture, out  val);
                return val;
            }
        }
        public override string Display => $"{DisplayName}";
        public override IExpression Clone => new Number("0");
        public override string RegExForm  => @"^-?\d+(\.\d+)?$";
        public override void PopExpressionInStarck(string element, Stack<IExpression> stack)
        {
            Element = element;
        }

    }
}
