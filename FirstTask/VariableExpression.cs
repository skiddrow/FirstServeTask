using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class VariableExpression : IExpression
    {
        ParameterExpression Parameter;

        public VariableExpression(ParameterExpression parameter)
        {
            Parameter = parameter;
        }

        public Expression Compute()
        {
            return Parameter;
        }
    }
}
