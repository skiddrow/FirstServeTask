using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class SubExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public SubExpression()
        { }

        public SubExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public double Compute()
        {
            return leftExpression.Compute() - rightExpression.Compute();
        }
    }
}
