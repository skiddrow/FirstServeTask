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
        private const string NumberPattern = @"^\d+(\.\d*)?";
        private const string AdditionPattern = @"^\+";
        private const string SubtractionPattern = @"^-";
        private const string MultiplicationPattern = @"^\*";
        private const string DivisionPattern = @"^/";
        private const string InvolutionPattern = @"^\^";
        private const string VariablePattern = @"^([A-Za-z][A-Za-z0-9]*)";
        private const string NonAlphanumericPattern = @"^\W";
        private static Regex NumberRegEx = new Regex(NumberPattern);
        private static Regex AdditionRegEx = new Regex(AdditionPattern);
        private static Regex SubtractionRegEx = new Regex(SubtractionPattern);
        private static Regex MultiplicationRegEx = new Regex(MultiplicationPattern);
        private static Regex DivisionRegEx = new Regex(DivisionPattern);
        private static Regex InvolutionRegEx = new Regex(InvolutionPattern);
        private static Regex VariableRegEx = new Regex(VariablePattern);
        private static Regex NonAlphanumericRegEx = new Regex(NonAlphanumericPattern);
        public static List<ParameterExpression> Parameters;

        static StringToExpressionConverter()
        {
            Parameters = new List<ParameterExpression>();
        }

        public static List<IExpression> ConvertStringsToExpressions(List<string> inputMembers)
        {
            List<IExpression> membersExpressions = new List<IExpression>();

            foreach (var member in inputMembers)
            {
                if (NumberRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new NumberExpression(Double.Parse(member)));
                }
                else if (VariableRegEx.IsMatch(member))
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(double), member);
                    membersExpressions.Add(new VariableExpression(parameter));
                    Parameters.Add(parameter);
                }
                else if (AdditionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new AddExpression());
                }
                else if (SubtractionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new SubExpression());
                }
                else if (MultiplicationRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new MulExpression());
                }
                else if (DivisionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new DivExpression());
                }
                else if (InvolutionRegEx.IsMatch(member))
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
            bool isFirstMemeberIsNumberOrVariable = !NumberRegEx.IsMatch(expression[0]) && !VariableRegEx.IsMatch(expression[0]);
            bool isLastMemeberIsNumberOrVariable = !NumberRegEx.IsMatch(expression[expressionLength - 1]) && !VariableRegEx.IsMatch(expression[expressionLength - 1]);

            if (isFirstMemeberIsNumberOrVariable || isLastMemeberIsNumberOrVariable)
            {
                return false;
            }

            for (int i = 0; i < expressionLength - 1; i++)
            {
                if (NonAlphanumericRegEx.IsMatch(expression[i]) && NonAlphanumericRegEx.IsMatch(expression[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
