using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class MulExpression : BinaryArithmeticExpression
    {
        public MulExpression()
            : base()
        { }

        public MulExpression(int priority)
        {
            Priority = priority;
        } 

        public MulExpression(IBasicExpression leftExpression, IBasicExpression rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression multiplicationExpression = Expression.Multiply(LeftExpression.Compute(), RightExpression.Compute());

            return multiplicationExpression;
        }
    }
}
