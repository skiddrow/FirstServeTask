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
        public static IBasicExpression GetExpressionTree(List<IBasicExpression> inputList)
        {
            for (int i = StringParser.MaxOperationPriority; i >= 0; i--)
            {
                int n = inputList.Count;

                for (int j = 1; j < n; j += 2)
                {
                    if (inputList[j] is InvolutionExpression && inputList[j].Priority == i)
                    {
                        var mulExp = inputList[j] as InvolutionExpression;
                        mulExp.LeftExpression = inputList[j - 1];
                        mulExp.RightExpression = inputList[j + 1];
                        inputList[j] = mulExp;
                        inputList.RemoveAt(j + 1);
                        inputList.RemoveAt(j - 1);
                        j -= 2;
                        n -= 2;
                    }
                }

                for (int j = 1; j < n; j += 2)
                {
                    if ((inputList[j] is MulExpression || inputList[j] is DivExpression) && inputList[j].Priority == i)
                    {
                        dynamic exp;

                        if (inputList[j] is MulExpression)
                        {
                            exp = inputList[j] as MulExpression;
                        }
                        else
                        {
                            exp = inputList[j] as DivExpression;
                        }

                        exp.LeftExpression = inputList[j - 1];
                        exp.RightExpression = inputList[j + 1];
                        inputList[j] = exp;
                        inputList.RemoveAt(j + 1);
                        inputList.RemoveAt(j - 1);
                        j -= 2;
                        n -= 2;
                    }
                }

                for (int j = 1; j < n; j += 2)
                {
                    if ((inputList[j] is AddExpression || inputList[j] is SubExpression) && inputList[j].Priority == i)
                    {
                        dynamic exp;

                        if (inputList[j] is AddExpression)
                        {
                            exp = inputList[j] as AddExpression;
                        }
                        else
                        {
                            exp = inputList[j] as SubExpression;
                        }

                        exp.LeftExpression = inputList[j - 1];
                        exp.RightExpression = inputList[j + 1];
                        inputList[j] = exp;
                        inputList.RemoveAt(j + 1);
                        inputList.RemoveAt(j - 1);
                        j -= 2;
                        n -= 2;
                    }
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

        public static T BuildFrom<T>(string formula) where T : class
        {
            var parsedString = StringParser.Parse(formula);

            if (parsedString == null)
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            IBasicExpression expressionTree = GetExpressionTree(parsedString);

            if (expressionTree == null)
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            return Expression.Lambda<T>(expressionTree.Compute(), StringToExpressionConverter.Parameters).Compile();
        }

    }
}
