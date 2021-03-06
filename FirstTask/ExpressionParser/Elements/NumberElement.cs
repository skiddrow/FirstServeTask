﻿using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class NumberElement : IBasicElement
    {
        public int Priority { get; set; }
        protected double Value;

        public NumberElement(double value)
        {
            this.Value = value;
        }

        public Expression Compute()
        {
            ConstantExpression constantExpression = Expression.Constant(Value);

            return constantExpression;
        }
    }
}
