using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class MulExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public MulExpression()
        { }

        public MulExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public double Compute()
        {
            return leftExpression.Compute() * rightExpression.Compute();
        }
    }
}
