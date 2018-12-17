using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class AbsElement : IBasicElement
    {
        public int Priority { get; set; }

        protected IBasicElement Value;

        public AbsElement(IBasicElement value)
        {
            this.Value = value;
        }

        public Expression Compute()
        {
            var expression = Expression.Call(
                null,
                typeof(Math).GetMethod("Abs", new Type[] { typeof(double)}),
                Value.Compute()
                );

            return expression;
        }
    }
}
