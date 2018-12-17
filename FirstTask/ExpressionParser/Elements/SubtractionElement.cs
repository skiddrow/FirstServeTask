using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class SubtractionElement : BinaryArithmeticElement
    {
        public SubtractionElement()
            : base()
        { }

        public SubtractionElement(int priority)
        {
            Priority = priority;
        } 

        public SubtractionElement(IBasicElement leftExpression, IBasicElement rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression subtractionExpression = Expression.Subtract(LeftExpression.Compute(), RightExpression.Compute());

            return subtractionExpression;
        }
    }
}
