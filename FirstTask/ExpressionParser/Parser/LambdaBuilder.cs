using FirstTask.ExpressionParser.Elements;
using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Parser
{
    static class LambdaBuilder
    {
        public static IBasicElement GetExpressionTree(List<IBasicElement> inputList)
        {
            for (int i = ExpressionsParser.MaxOperationPriority; i >= 0; i--)
            {
                int n = inputList.Count;

                for (int j = 1; j < n; j += 2)
                {
                    if (inputList[j] is InvolutionElement && inputList[j].Priority == i)
                    {
                        var mulExp = inputList[j] as InvolutionElement;
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
                    if ((inputList[j] is MultiplicationElement || inputList[j] is DivisionElement) && inputList[j].Priority == i)
                    {
                        BinaryArithmeticElement exp;

                        if (inputList[j] is MultiplicationElement)
                        {
                            exp = inputList[j] as MultiplicationElement;
                        }
                        else
                        {
                            exp = inputList[j] as DivisionElement;
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
                    if ((inputList[j] is AdditionElement || inputList[j] is SubtractionElement) && inputList[j].Priority == i)
                    {
                        BinaryArithmeticElement exp;

                        if (inputList[j] is AdditionElement)
                        {
                            exp = inputList[j] as AdditionElement;
                        }
                        else
                        {
                            exp = inputList[j] as SubtractionElement;
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
            var tokenizedString = StringTokenizer.Parse(formula);

            if (tokenizedString == null)
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            var parsedExpressions = ExpressionsParser.ConvertStringsToExpressions(tokenizedString);

            if (parsedExpressions == null)
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            var expressionTree = GetExpressionTree(parsedExpressions);

            if (expressionTree == null)
            {
                Console.WriteLine("Input expression has incorrect format");

                return null;
            }

            return Expression.Lambda<T>(expressionTree.Compute(), ExpressionsParser.Parameters).Compile();
        }

    }
}
