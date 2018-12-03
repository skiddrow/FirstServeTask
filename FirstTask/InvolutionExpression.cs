using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class InvolutionExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public InvolutionExpression()
        { }

        public InvolutionExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public double Compute(Context context)
        {
            return Math.Pow(leftExpression.Compute(context), rightExpression.Compute(context));
        }
    }
}
