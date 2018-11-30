using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class NumberExpression : IExpression
    {
        double value;

        public NumberExpression(double value)
        {
            this.value = value;
        }

        public double Compute()
        {
            return value;
        }
    }
}
