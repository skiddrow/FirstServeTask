using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser
{
    class AbsExpression : NumberExpression
    {
        public Expression Compute()
        {
            return Expression.Constant(Math.Abs(Value));
        }
    }
}
