using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    abstract class BinaryArithmeticExpression : IBasicExpression
    {
        public IBasicExpression LeftExpression { get; set; }
        public IBasicExpression RightExpression { get; set; }
        public int Priority { get; set; }

        public BinaryArithmeticExpression()
        {
            Priority = 0;
        }

        public BinaryArithmeticExpression(IBasicExpression leftExpression, IBasicExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public abstract Expression Compute();
    }
}
