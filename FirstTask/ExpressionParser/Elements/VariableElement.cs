using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Elements
{
    class VariableElement : IBasicElement
    {
        private ParameterExpression Parameter;

        public int Priority { get; set; }

        public VariableElement(ParameterExpression parameter)
        {
            Parameter = parameter;
        }

        public Expression Compute()
        {
            return Parameter;
        }
    }
}
