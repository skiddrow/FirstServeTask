using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class DivisionElement : BinaryArithmeticElement
    {
        public DivisionElement()
            : base()
        { }

        public DivisionElement(int priority)
        {
            Priority = priority;
        } 

        public DivisionElement(IBasicElement leftExpression, IBasicElement rightExpression)
            : base(leftExpression, rightExpression)
        { }

        public override Expression Compute()
        {
            Expression divisionExpression = Expression.Divide(LeftExpression.Compute(), RightExpression.Compute());

            return divisionExpression;
        }
    }
}
