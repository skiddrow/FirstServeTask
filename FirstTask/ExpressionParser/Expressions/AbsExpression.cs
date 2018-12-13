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
        public int Priority { get; set; }

        protected IBasicExpression Value;

        public AbsExpression(IBasicExpression value)
        {
            this.Value = value;
        }

        public Expression Compute()
        {

            var exp = Expression.Call(
                null,
                typeof(Math).GetMethod("Abs", new Type[] { typeof(double)}),
                Value.Compute()
                );
            //var expression = Expression.IfThenElse(
            //    Expression.GreaterThanOrEqual(Value.Compute(), Expression.Constant(0)),
            //    Value.Compute(),
            //    Expression.Multiply(Value.Compute(), Expression.Constant(-1))
            //    );      

            //var expression = Expression.Assign()

            return exp;
        }

    }
}
