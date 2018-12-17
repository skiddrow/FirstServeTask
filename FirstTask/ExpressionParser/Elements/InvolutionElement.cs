using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class InvolutionElement : BinaryArithmeticElement
    {
        public InvolutionElement()
            : base()
        { }

        public InvolutionElement(int priority)
        {
            Priority = priority;
        } 

        public InvolutionElement(IBasicElement leftExpression, IBasicElement rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression involutionExpression = Expression.Power(LeftExpression.Compute(), RightExpression.Compute());

            return involutionExpression;
        }
    }
}
