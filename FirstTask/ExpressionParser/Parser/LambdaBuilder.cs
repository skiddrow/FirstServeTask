﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    static class LambdaBuilder
    {
        public static IBasicExpression GetExpressionTree(List<object> inputList)
        {
            int n = inputList.Count;

            for (int i = 1; i < n; i += 2)
            {
                if (inputList[i] is InvolutionExpression)
                {
                    var mulExp = inputList[i] as InvolutionExpression;
                    mulExp.LeftExpression = inputList[i - 1] as IBasicExpression;
                    mulExp.RightExpression = inputList[i + 1] as IBasicExpression;
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

                    exp.LeftExpression = inputList[i - 1] as IBasicExpression;
                    exp.RightExpression = inputList[i + 1] as IBasicExpression;
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

                    exp.LeftExpression = inputList[i - 1] as IBasicExpression;
                    exp.RightExpression = inputList[i + 1] as IBasicExpression;
                    inputList[i] = exp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                    i -= 2;
                    n -= 2;
                }
            }

            if (inputList.Count == 1)
            {
                return inputList[0] as IBasicExpression;
            }
            else
            {
                return null;
            }
        }

        public static T BuildFrom<T>(string formula) where T : class
        {
            List<object> parsedString = StringParser.Parse(formula);

            if (!StringToExpressionConverter.IsCorrectExpression(parsedString))
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            List<object> expressionsList = StringToExpressionConverter.ConvertStringsToExpressions(parsedString);
            IBasicExpression expressionTree = GetExpressionTree(expressionsList);

            if (expressionsList == null)
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            return Expression.Lambda<T>(expressionTree.Compute(), StringToExpressionConverter.Parameters).Compile();
        }

    }
}