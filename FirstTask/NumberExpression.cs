using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class NumberExpression : IExpression
    {
        private double Value;

        public NumberExpression(double value)
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
