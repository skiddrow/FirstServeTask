using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class NumberExpression : IExpression
    {
        private double Value;

        public NumberExpression(double value)
        {
            this.Value = value;
        }

        public double Compute(Context context)
        {
            return Value;
        }
    }
}
