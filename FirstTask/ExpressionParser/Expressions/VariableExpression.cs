using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class VariableExpression : IBasicExpression
    {
        private ParameterExpression Parameter;

        public int Priority { get; set; }

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
