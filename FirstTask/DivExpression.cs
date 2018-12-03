using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class DivExpression : IExpression
    {
        public IExpression leftExpression { get; set; }
        public IExpression rightExpression { get; set; }

        public DivExpression()
        { }

        public DivExpression(IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public double Compute(Context context)
        {
            if (rightExpression.Compute(context) != 0)
            {
                return leftExpression.Compute(context) / rightExpression.Compute(context);
            }
            else
            {
                return double.NaN;
            }
        }
    }
}
