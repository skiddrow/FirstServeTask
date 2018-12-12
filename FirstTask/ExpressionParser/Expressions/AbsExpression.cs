using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class AbsExpression : IBasicExpression
    {
        protected IBasicExpression Value;

        public AbsExpression(IBasicExpression value)
        {
            this.Value = value;
        }

        public Expression Compute()
        {
            var expression = Expression.IfThenElse(
                Expression.GreaterThanOrEqual(Value.Compute(), Expression.Constant(0)),
                Value.Compute(),
                Expression.Multiply(Value.Compute(), Expression.Constant(-1))
                );      

            //var expression = Expression.Assign()

            return expression;
        }
    }
}
