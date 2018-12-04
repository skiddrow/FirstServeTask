using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    static class LambdaBuilder
    {
        private static IExpression GetExpressionTree(List<IExpression> inputList)
        {
            int n = inputList.Count;

            for (int i = 1; i < n; i += 2)
            {
                if (inputList[i] is InvolutionExpression)
                {
                    var mulExp = inputList[i] as InvolutionExpression;
                    mulExp.leftExpression = inputList[i - 1];
                    mulExp.rightExpression = inputList[i + 1];
                    inputList[i] = mulExp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                    i -= 2;
                    n -= 2;
                }
            }

            for (int i = 1; i < n; i += 2)
            {
                if (inputList[i] is MulExpression || inputList[i] is DivExpression)
                {
                    dynamic exp;

                    if (inputList[i] is MulExpression)
                    {
                        exp = inputList[i] as MulExpression;
                    }
                    else
                    {
                        exp = inputList[i] as DivExpression;
                    }

                    exp.leftExpression = inputList[i - 1];
                    exp.rightExpression = inputList[i + 1];
                    inputList[i] = exp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                    i -= 2;
                    n -= 2;
                }
            }

            for (int i = 1; i < n; i += 2)
            {
                if (inputList[i] is AddExpression || inputList[i] is SubExpression)
                {
                    dynamic exp;

                    if (inputList[i] is AddExpression)
                    {
                        exp = inputList[i] as AddExpression;
                    }
                    else
                    {
                        exp = inputList[i] as SubExpression;
                    }

                    exp.leftExpression = inputList[i - 1];
                    exp.rightExpression = inputList[i + 1];
                    inputList[i] = exp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                    i -= 2;
                    n -= 2;
                }
            }

            if (inputList.Count == 1)
            {
                return inputList[0];
            }
            else
            {
                return null;
            }
        }

        public static Delegate BuildFrom<T>(string formula)
        {
            List<string> parsedString = StringParser.Parse(formula);

            if (!StringToExpressionConverter.IsCorrectExpression(parsedString))
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            List<IExpression> expressionsList = StringToExpressionConverter.ConvertStringsToExpressions(parsedString);
            IExpression expressionTree = GetExpressionTree(expressionsList);
            LambdaExpression lambdaExpression = Expression.Lambda(expressionTree.Compute(),StringToExpressionConverter.Parameters);
            var newLambda = lambdaExpression.Compile();

            return newLambda;
        }

    }
}
