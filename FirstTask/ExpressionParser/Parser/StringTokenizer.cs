﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FirstTask.Enums;

namespace FirstTask.ExpressionParser.Parser
{
    static class StringTokenizer
    {
        public const string NumberPattern = @"^\d+(,\d*)?";
        public const string AdditionPattern = @"^\+";
        public const string SubtractionPattern = @"^-";
        public const string MultiplicationPattern = @"^\*";
        public const string DivisionPattern = @"^/";
        public const string InvolutionPattern = @"^\^";
        public const string VariablePattern = @"[A-Za-z][A-Za-z0-9]*";
        public const string ArithmeticalSymbolPattern = @"^(\+|-|\*|\/|\^)";
        public const string OpeningBracketPattern = @"^\(";
        public const string ClosingBracketPattern = @"^\)";
        public const string AbsPattern = @"^Abs\(";

        public static ElementType PreviousOperation = 0;
        public static readonly Regex NumberRegEx = new Regex(NumberPattern);
        public static readonly Regex AdditionRegEx = new Regex(AdditionPattern);
        public static readonly Regex SubtractionRegEx = new Regex(SubtractionPattern);
        public static readonly Regex MultiplicationRegEx = new Regex(MultiplicationPattern);
        public static readonly Regex DivisionRegEx = new Regex(DivisionPattern);
        public static readonly Regex InvolutionRegEx = new Regex(InvolutionPattern);
        public static readonly Regex VariableRegEx = new Regex(VariablePattern);
        public static readonly Regex ArithmeticalSymbolRegEx = new Regex(ArithmeticalSymbolPattern);
        public static readonly Regex OpeningBracketRegEx = new Regex(OpeningBracketPattern);
        public static readonly Regex ClosingBracketRegEx = new Regex(ClosingBracketPattern);
        public static readonly Regex AbsRegEx = new Regex(AbsPattern);

        public static List<string> Parse(string input)
        {
            var splittedMembers = new List<string>();
            input = input.Replace(" ", "");
            var parsers = new List<SymbolParser>();

            if (!IsBracketsOkay(input))
            {
                Console.WriteLine("Input string has incorrect count of brackets!");

                return null;
            }

            parsers.Add(new SymbolParser(NumberRegEx, ElementType.Number));
            parsers.Add(new SymbolParser(AbsRegEx, ElementType.Abs));
            parsers.Add(new SymbolParser(VariableRegEx, ElementType.Variable));
            parsers.Add(new SymbolParser(ArithmeticalSymbolRegEx, ElementType.Operation));
            parsers.Add(new SymbolParser(OpeningBracketRegEx, ElementType.OpeningBracket));
            parsers.Add(new SymbolParser(ClosingBracketRegEx, ElementType.ClosingBracket));

            while (input.Length != 0)
            {
                var currentParser = parsers.FirstOrDefault(p => p.IsParsebleSymbol(input));
                var match = currentParser.GetMatch(input);
                currentParser.CutString(ref input, match);
                var currentExpressionType = currentParser.GetExpressionType();

                if ((currentExpressionType == PreviousOperation) &&
                    currentExpressionType != ElementType.OpeningBracket &&
                    currentExpressionType != ElementType.ClosingBracket)
                {
                    Console.WriteLine("Input string cannot contains two arithmetical symbols in a row!");
                    return null;
                }

                PreviousOperation = currentExpressionType;

                splittedMembers.Add(match);
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

        public static ElementType GetExpressionType(ElementType currentType)
        {
            return currentType == ElementType.OpeningBracket || currentType == ElementType.ClosingBracket
                ? PreviousOperation : currentType;
        }
    }
}
