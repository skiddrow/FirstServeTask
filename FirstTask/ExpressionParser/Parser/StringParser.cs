using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask
{
    static class StringParser
    {
        public const string NumberPattern = @"^\d+(,\d*)?";
        public const string AdditionPattern = @"^\+";
        public const string SubtractionPattern = @"^-";
        public const string MultiplicationPattern = @"^\*";
        public const string DivisionPattern = @"^/";
        public const string InvolutionPattern = @"^\^";
        public const string VariablePattern = @"^([A-Za-z][A-Za-z0-9]*)";
        public const string ArithmeticalSymbolPattern = @"^(\+|-|\*|\/|\^)";
        public const string BracketsPattern = @"^(\(|\))";
        public const string AbsPattern = @"^Abs\(";

        public static int OperationPriority = 0;
        public static int MaxOperationPriority = 0;
        public static ExpressionType PreviousOperation = 0;
        public static readonly Regex NumberRegEx = new Regex(NumberPattern);
        public static readonly Regex AdditionRegEx = new Regex(AdditionPattern);
        public static readonly Regex SubtractionRegEx = new Regex(SubtractionPattern);
        public static readonly Regex MultiplicationRegEx = new Regex(MultiplicationPattern);
        public static readonly Regex DivisionRegEx = new Regex(DivisionPattern);
        public static readonly Regex InvolutionRegEx = new Regex(InvolutionPattern);
        public static readonly Regex VariableRegEx = new Regex(VariablePattern);
        public static readonly Regex ArithmeticalSymbolRegEx = new Regex(ArithmeticalSymbolPattern);
        public static readonly Regex BracketsRegEx = new Regex(BracketsPattern);
        public static readonly Regex AbsRegEx = new Regex(AbsPattern);

        public static void Parse2_0(string input)
        {
            List<SymbolParser> parsers = new List<SymbolParser>();
            double numberValue = 0;
            IBasicExpression expressionForAbs = null;
            ParameterExpression parameterForVariable = null;

            parsers.Add(new SymbolParser(NumberRegEx, () => new NumberExpression(numberValue)));
            parsers.Add(new SymbolParser(AbsRegEx, () => new AbsExpression(expressionForAbs)));
            parsers.Add(new SymbolParser(VariableRegEx, () => new VariableExpression(parameterForVariable)));
            parsers.Add(new SymbolParser(ArithmeticalSymbolRegEx, () => new DivExpression()));
            parsers.Add(new SymbolParser(BracketsRegEx, () => new DivExpression()));

            while (input.Length != 0)
            {
                var currentParser = parsers.FirstOrDefault(p => p.IsParsebleSymbol(input));
                var expression = currentParser.Del();
                var match = currentParser.Regex.Match(input).Value;
                Console.WriteLine(match);
                input = input.Substring(match.Length, input.Length - match.Length);
            }
        }

        public static List<IBasicExpression> Parse(string input)
        {
            var splittedMembers = new List<IBasicExpression>();
            input = input.Replace(" ", "");
            string findedValue = "";

            if (!IsBracketsOkay(input))
            {
                Console.WriteLine("Input string has incorrect count of brackets!");

                return null;
            }

            while (input.Length != 0)
            {
                if (NumberRegEx.IsMatch(input))
                {
                    findedValue = NumberRegEx.Match(input).Value;
                    input = input.Substring(findedValue.Length, input.Length - findedValue.Length);
                    PreviousOperation = ExpressionType.Number;
                    var expression = StringToExpressionConverter.ConvertStringToExpression(findedValue, ExpressionType.Number);
                    splittedMembers.Add(expression);
                }
                else if (AbsRegEx.IsMatch(input))
                {
                    findedValue = AbsRegEx.Match(input).Value;
                    input = input.Substring(findedValue.Length, input.Length - findedValue.Length);
                    
                    PreviousOperation = ExpressionType.Abs;
                    var absExpression = ParseAbsExpression(ref input);
                    var expTree = LambdaBuilder.GetExpressionTree(absExpression);
                    splittedMembers.Add(new AbsExpression(expTree));
                }
                else if (VariableRegEx.IsMatch(input))
                {
                    findedValue = VariableRegEx.Match(input).Value;
                    input = input.Substring(findedValue.Length, input.Length - findedValue.Length);
                    PreviousOperation = ExpressionType.Variable;
                    var expression = StringToExpressionConverter.ConvertStringToExpression(findedValue, ExpressionType.Variable);
                    splittedMembers.Add(expression);
                }
                else if (ArithmeticalSymbolRegEx.IsMatch(input))
                {
                    findedValue = ArithmeticalSymbolRegEx.Match(input).Value;
                    input = input.Substring(findedValue.Length, input.Length - findedValue.Length);

                    if (PreviousOperation == ExpressionType.Operation)
                    {
                        Console.WriteLine("Input string cannot contains two arithmetical symbols in a row!");

                        return null;
                    }

                    PreviousOperation = ExpressionType.Operation;
                    var expression = StringToExpressionConverter.ConvertStringToExpression(findedValue, ExpressionType.Operation);
                    splittedMembers.Add(expression);
                }
                else if (BracketsRegEx.IsMatch(input))
                {
                    findedValue = BracketsRegEx.Match(input).Value;
                    input = input.Substring(findedValue.Length, input.Length - findedValue.Length);

                    if (findedValue == "(")
                    {
                        OperationPriority++;
                        MaxOperationPriority = OperationPriority > MaxOperationPriority ? OperationPriority : MaxOperationPriority;
                    }
                    else
                    {
                        OperationPriority--;
                    }
                }
                else
                {
                    Console.WriteLine("Input string has incorrect values!");
                    return null;
                }
            }

            return splittedMembers;
        }

        public static bool IsBracketsOkay(string input)
        {
            int countOfOpeningBrackets = 0;
            int countOfClosingBrackets = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    countOfOpeningBrackets++;
                }
                else if (input[i] == ')')
                {
                    countOfClosingBrackets++;
                }

                if (countOfClosingBrackets > countOfOpeningBrackets)
                {
                    return false;
                }
            }

            if (countOfClosingBrackets != countOfOpeningBrackets)
            {
                return false;
            }

            return true;
        }

        public static List<IBasicExpression> ParseAbsExpression(ref string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            int countOfOpennigBrackets = 1;
            int countOfClosingBrackets = 0;
            int substringIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    countOfOpennigBrackets++;
                }
                else if (input[i] == ')')
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

            string absExpression = input.Substring(0, substringIndex);
            input = input.Substring(substringIndex + 1);
            var parsedExpression = Parse(absExpression);

            return parsedExpression;
        }
    }
}
