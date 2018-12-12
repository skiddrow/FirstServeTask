using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class AddExpression : BinaryArithmeticExpression
    {
        public AddExpression()
            : base()
        { } 

        public AddExpression(IBasicExpression leftExpression, IBasicExpression rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression additionExpression = Expression.Add(LeftExpression.Compute(), RightExpression.Compute());

            return additionExpression;
        }
    }
}
