﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculatorKata.Operators
{
  public  class Plus : IExpression
  {
      public TypeOpeator typeOp
      {
          get => TypeOpeator.BI;

      }

        private string _element;

      public Plus(string element)
      {
          _element = element;
      }
       
        public IExpression Exp1 { get; set; }
        public IExpression Exp2 { get; set; }
        public double Evaluate()
        {
           return Exp1.Evaluate()+Exp2.Evaluate();
        }

        public string Display()
        {
            return $"({Exp1.Display()}{_element}{Exp2.Display()})";
        }

      public IExpression Clone()
      {
          return new Plus(_element);
        }
  }
}
