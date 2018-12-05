using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class DivExpression : BinaryArithmeticExpression
    {
        public DivExpression()
        { }

        public DivExpression(IBasicExpression leftExpression, IBasicExpression rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression divisionExpression = Expression.Divide(LeftExpression.Compute(), RightExpression.Compute());

            return divisionExpression;
        }
    }
}
