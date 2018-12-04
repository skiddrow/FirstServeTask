using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class AddExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public AddExpression()
        { }

        public AddExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public Expression Compute()
        {
            Expression additionExpression = Expression.Add(leftExpression.Compute(),rightExpression.Compute());

            return additionExpression;
        }
    }
}
