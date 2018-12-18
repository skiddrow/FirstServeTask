using FirstTask.ExpressionParser.Elements;
using FirstTask.ExpressionParser.Interfaces;
using FirstTask.ExpressionParser.Parser.ElementParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Parser
{
    static class ExpressionsParser
    {
        public static List<ParameterExpression> Parameters;
        public static int OperationPriority = 0;
        public static int MaxOperationPriority = 0;
        public static string CurrentSymbol = "";

        static ExpressionsParser()
        {
            Parameters = new List<ParameterExpression>();
        }

        public static List<IBasicElement> ConvertStringsToExpressions(List<string> inputValues)
        {
            var convertedElements = new List<IBasicElement>();
            var parsers = new List<ExpressionConvertor>();

            parsers.Add(new NumberConverter(StringTokenizer.NumberRegEx));
            parsers.Add(new ExpressionConvertor(StringTokenizer.AbsRegEx, null));
            parsers.Add(new VariableConverter(StringTokenizer.VariableRegEx));
            parsers.Add(new ExpressionConvertor(StringTokenizer.AdditionRegEx, () => new AdditionElement(OperationPriority)));
            parsers.Add(new ExpressionConvertor(StringTokenizer.SubtractionRegEx, () => new SubtractionElement(OperationPriority)));
            parsers.Add(new ExpressionConvertor(StringTokenizer.MultiplicationRegEx, () => new MultiplicationElement(OperationPriority)));
            parsers.Add(new ExpressionConvertor(StringTokenizer.DivisionRegEx, () => new DivisionElement(OperationPriority)));
            parsers.Add(new ExpressionConvertor(StringTokenizer.InvolutionRegEx, () => new InvolutionElement(OperationPriority)));
            parsers.Add(new ExpressionConvertor(StringTokenizer.OpeningBracketRegEx, IncrementPriority));
            parsers.Add(new ExpressionConvertor(StringTokenizer.ClosingBracketRegEx, DecrementPriority));

            while (inputValues.Count > 0)
            {
                var currentParser = parsers.FirstOrDefault(parser => parser.IsParsebleSymbol(inputValues[0]));

                if (currentParser.Regex == StringTokenizer.AbsRegEx)
                {
                    var parsedAbs = HandleAbsExpression(inputValues);

                    if (parsedAbs == null)
                    {
                        Console.WriteLine("Incorrect Abs() arguments!");

                        return null;
                    }

                    var absExpression = new AbsElement(parsedAbs);
                    convertedElements.Add(absExpression);
                }
                else
                {
                    CurrentSymbol = inputValues[0];
                    var currentElement = currentParser.ExecuteFunc();
                    convertedElements.Add(currentElement);
                    inputValues.Remove(inputValues[0]);
                }
            }

            convertedElements = convertedElements
                .Where(element => element != null)
                .ToList();

            return convertedElements;
        }

        public static IBasicElement IncrementPriority()
        {
            OperationPriority++;
            MaxOperationPriority = OperationPriority > MaxOperationPriority ? OperationPriority : MaxOperationPriority;

            return null;
        }

        public static IBasicElement DecrementPriority()
        {
            OperationPriority--;

            return null;
        }

        public static IBasicElement HandleAbsExpression(List<string> input)
        {
            int countOfOpennigBrackets = 1;
            int countOfClosingBrackets = 0;
            int substringIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "(")
                {
                    countOfOpennigBrackets++;
                }
                else if (input[i] == ")")
                {
                    countOfClosingBrackets++;
                }

                if (countOfOpennigBrackets == countOfClosingBrackets)
                {
                    substringIndex = i;
                    break;
                }
            }

            if (substringIndex == 0)
            {
                return null;
            }

            int handledCount = substringIndex + 1;
            int initialCopyIndex = 1;
            int arraysinitialCopyIndex = 0;
            int finalCopyIndex = substringIndex - 1;
            var absExpression = new string[handledCount - 2];
            input.CopyTo(initialCopyIndex, absExpression, arraysinitialCopyIndex, finalCopyIndex);
            var expressionsList = absExpression.ToList();
            input.RemoveRange(0, handledCount);
            var parsedExpression = ExpressionsParser.ConvertStringsToExpressions(expressionsList);
            var expressionTree = LambdaBuilder.GetExpressionTree(parsedExpression);

            return expressionTree;
        }
    }
}
