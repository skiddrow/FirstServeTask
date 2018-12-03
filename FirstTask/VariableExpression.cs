using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class VariableExpression : IExpression
    {
        private string Name;

        public VariableExpression(string name, Context context)
        {
            Name = name;
            context.AddVar(name, Double.NaN);
        }

        public double Compute(Context context)
        {
            return context.GetVar(Name);
        }
    }
}
