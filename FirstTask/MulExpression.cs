using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class MulExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public MulExpression()
        { }

        public MulExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public Expression Compute()
        {
            Expression multiplicationExpression = Expression.Multiply(leftExpression.Compute(), rightExpression.Compute());

            return multiplicationExpression;
        }
    }
}
