using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask
{
    static class StringToExpressionConverter
    {
        public static List<ParameterExpression> Parameters;

        static StringToExpressionConverter()
        {
            Parameters = new List<ParameterExpression>();
        }

        public static IBasicExpression ConvertStringToExpression(string inputValue, ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Number:
                    return new NumberExpression(Double.Parse(inputValue));
                case ExpressionType.Variable:
                    ParameterExpression parameter = Expression.Parameter(typeof(double), inputValue.ToString());
                    Parameters.Add(parameter);

                    return new VariableExpression(parameter);
                case ExpressionType.Operation:
                    if (StringParser.AdditionRegEx.IsMatch(inputValue))
                    {
                        return new AddExpression(StringParser.OperationPriority);
                    }
                    else if (StringParser.SubtractionRegEx.IsMatch(inputValue))
                    {
                        return new SubExpression(StringParser.OperationPriority);
                    }
                    else if (StringParser.MultiplicationRegEx.IsMatch(inputValue))
                    {
                        return new MulExpression(StringParser.OperationPriority);
                    }
                    else if (StringParser.DivisionRegEx.IsMatch(inputValue))
                    {
                        return new DivExpression(StringParser.OperationPriority);
                    }
                    else if (StringParser.InvolutionRegEx.IsMatch(inputValue))
                    {
                        return new InvolutionExpression(StringParser.OperationPriority);
                    }

                    break;
                default:
                    return null;
            }

            return null;
        }
    }
}
