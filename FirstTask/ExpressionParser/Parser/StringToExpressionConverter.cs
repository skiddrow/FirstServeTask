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
        //public static Dictionary<string, object> InBracketsExpressions;

        static StringToExpressionConverter()
        {
            Parameters = new List<ParameterExpression>();
            //InBracketsExpressions = new Dictionary<string, object>();
        }

        public static List<object> ConvertStringsToExpressions(List<object> inputMembers)
        {
            //List<IBasicExpression> membersExpressions = new List<IBasicExpression>();
            List<object> membersExpressions = new List<object>();

            foreach (var member in inputMembers)
            {
                if (StringParser.NumberRegEx.IsMatch(member.ToString()))
                {
                    membersExpressions.Add(new NumberExpression(Double.Parse(member.ToString())));
                }
                else if (StringParser.VariableRegEx.IsMatch(member.ToString()))
                {
                    ParameterExpression parameter = Expression.Parameter(typeof(double), member.ToString());
                    membersExpressions.Add(new VariableExpression(parameter));
                    Parameters.Add(parameter);
                }
                else if (StringParser.AdditionRegEx.IsMatch(member.ToString()))
                {
                    membersExpressions.Add(new AddExpression());
                }
                else if (StringParser.SubtractionRegEx.IsMatch(member.ToString()))
                {
                    membersExpressions.Add(new SubExpression());
                }
                else if (StringParser.MultiplicationRegEx.IsMatch(member.ToString()))
                {
                    membersExpressions.Add(new MulExpression());
                }
                else if (StringParser.DivisionRegEx.IsMatch(member.ToString()))
                {
                    membersExpressions.Add(new DivExpression());
                }
                else if (StringParser.InvolutionRegEx.IsMatch(member.ToString()))
                {
                    membersExpressions.Add(new InvolutionExpression());
                }
            }

            return membersExpressions;
            //return inputMembers;
        }

        public static bool IsCorrectExpression(List<object> expression)
        {
            if (expression == null)
            {
                return false;
            }


            int expressionLength = expression.Count;
            bool isEdgeMembesrIsIncorrect = StringParser.ArithmeticalSymbolRegEx.IsMatch(expression[0].ToString()) || StringParser.ArithmeticalSymbolRegEx.IsMatch(expression[expressionLength - 1].ToString());

            if (isEdgeMembesrIsIncorrect)
            {
                return false;
            }

            for (int validatorLoopCounter = 0; validatorLoopCounter < expressionLength - 1; validatorLoopCounter++)
            {
                if (StringParser.ArithmeticalSymbolRegEx.IsMatch(expression[validatorLoopCounter].ToString()) && StringParser.ArithmeticalSymbolRegEx.IsMatch(expression[validatorLoopCounter + 1].ToString()))
                {
                    return false;
                }

                if (StringParser.NumberRegEx.IsMatch(expression[validatorLoopCounter].ToString()) &&
                    StringParser.VariableRegEx.IsMatch(expression[validatorLoopCounter + 1].ToString()))
                {
                    return false;
                }

                if (StringParser.VariableRegEx.IsMatch(expression[validatorLoopCounter].ToString()) &&
                    StringParser.NumberRegEx.IsMatch(expression[validatorLoopCounter + 1].ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
