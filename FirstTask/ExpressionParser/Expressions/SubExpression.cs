﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class SubExpression : BinaryArithmeticExpression
    {
        public SubExpression()
            : base()
        { }

        public SubExpression(int priority)
        {
            Priority = priority;
        } 

        public SubExpression(IBasicExpression leftExpression, IBasicExpression rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression subtractionExpression = Expression.Subtract(LeftExpression.Compute(), RightExpression.Compute());

            return subtractionExpression;
        }
    }
}
