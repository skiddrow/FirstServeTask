using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class InvolutionExpression : BinaryArithmeticExpression
    {
        public InvolutionExpression()
        { }

        public InvolutionExpression(IBasicExpression leftExpression, IBasicExpression rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression involutionExpression = Expression.Power(LeftExpression.Compute(), RightExpression.Compute());

            return involutionExpression;
        }
    }
}
