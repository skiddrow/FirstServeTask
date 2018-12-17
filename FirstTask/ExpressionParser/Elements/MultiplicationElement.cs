using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class MultiplicationElement : BinaryArithmeticElement
    {
        public MultiplicationElement()
            : base()
        { }

        public MultiplicationElement(int priority)
        {
            Priority = priority;
        } 

        public MultiplicationElement(IBasicElement leftExpression, IBasicElement rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression multiplicationExpression = Expression.Multiply(LeftExpression.Compute(), RightExpression.Compute());

            return multiplicationExpression;
        }
    }
}
