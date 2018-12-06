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

        public static List<IBasicExpression> ConvertStringsToExpressions(List<string> inputMembers)
        {
            List<IBasicExpression> membersExpressions = new List<IBasicExpression>();

            foreach (var member in inputMembers)
            {
                if (StringParser.NumberRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new NumberExpression(Double.Parse(member)));
                }
                else if (StringParser.VariableRegEx.IsMatch(member))
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(double), member);
                    membersExpressions.Add(new VariableExpression(parameter));
                    Parameters.Add(parameter);
                }
                else if (StringParser.AdditionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new AddExpression());
                }
                else if (StringParser.SubtractionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new SubExpression());
                }
                else if (StringParser.MultiplicationRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new MulExpression());
                }
                else if (StringParser.DivisionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new DivExpression());
                }
                else if (StringParser.InvolutionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new InvolutionExpression());
                }
            }

            return membersExpressions;
        }

        public static bool IsCorrectExpression(List<string> expression)
        {
            if (expression == null)
            {
                return false;
            }

            int expressionLength = expression.Count;
            bool isFirstMemeberIsNumberOrVariable = !StringParser.NumberRegEx.IsMatch(expression[0]) && !StringParser.VariableRegEx.IsMatch(expression[0]);
            bool isLastMemeberIsNumberOrVariable = !StringParser.NumberRegEx.IsMatch(expression[expressionLength - 1]) && !StringParser.VariableRegEx.IsMatch(expression[expressionLength - 1]);

            if (isFirstMemeberIsNumberOrVariable || isLastMemeberIsNumberOrVariable)
            {
                return false;
            }

            for (int i = 0; i < expressionLength - 1; i++)
            {
                if (StringParser.NonAlphanumericRegEx.IsMatch(expression[i]) && StringParser.NonAlphanumericRegEx.IsMatch(expression[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
