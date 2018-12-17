using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    abstract class BinaryArithmeticElement : IBasicElement
    {
        public IBasicElement LeftExpression { get; set; }
        public IBasicElement RightExpression { get; set; }
        public int Priority { get; set; }

        public BinaryArithmeticElement()
        {
            Priority = 0;
        }

        public BinaryArithmeticElement(IBasicElement leftExpression, IBasicElement rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public abstract Expression Compute();
    }
}
