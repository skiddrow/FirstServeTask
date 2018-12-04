using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class SubExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public SubExpression()
        { }

        public SubExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public Expression Compute()
        {
            Expression subtractionExpression = Expression.Subtract(leftExpression.Compute(), rightExpression.Compute());

            return subtractionExpression;
        }
    }
}
