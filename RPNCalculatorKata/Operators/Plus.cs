﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
  public  class Plus : AExpression
    {
        public Plus()
        {
            Element = "+";
        }
        public override string DisplayName => "+";
        public override TypeOpeator TypeOp { get; } = TypeOpeator.BI;
        public override double Evaluate => Exp1.Evaluate + Exp2.Evaluate;
        public override string Display => $"({Exp1.Display}{DisplayName}{Exp2.Display})";
        public override IExpression Clone => new Plus();
        public override string RegExForm  => @"\+";

    }
}
