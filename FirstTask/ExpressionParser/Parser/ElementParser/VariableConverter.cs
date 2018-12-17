using FirstTask.ExpressionParser.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Parser.ElementParser
{
    class VariableConverter : ExpressionConvertor
    {
        public VariableConverter(Regex symbolRegex)
        {
            Regex = symbolRegex;
            Function = () => new VariableElement(GetExpression());
        }

        public ParameterExpression GetExpression()
        {
            var parameter = Expression.Parameter(typeof(double), ExpressionsParser.CurrentSymbol);
            ExpressionsParser.Parameters.Add(parameter);

            return parameter;
        }
    }
}
