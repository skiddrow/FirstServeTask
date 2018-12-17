using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class AdditionElement : BinaryArithmeticElement
    {
        public AdditionElement()
            : base()
        { }

        public AdditionElement(int priority)
        {
            Priority = priority;
        } 

        public AdditionElement(IBasicElement leftExpression, IBasicElement rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression additionExpression = Expression.Add(LeftExpression.Compute(), RightExpression.Compute());

            return additionExpression;
        }
    }
}
