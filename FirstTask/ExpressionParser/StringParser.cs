using System;
using System.Collections.Generic;
using System.Linq;
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
        public const string NonAlphanumericPattern = @"^\W";
        public const string ArithmeticalSymbolPattern = @"^(\+|-|\*|\/|\^)";
        public static readonly Regex NumberRegEx = new Regex(NumberPattern);
        public static readonly Regex AdditionRegEx = new Regex(AdditionPattern);
        public static readonly Regex SubtractionRegEx = new Regex(SubtractionPattern);
        public static readonly Regex MultiplicationRegEx = new Regex(MultiplicationPattern);
        public static readonly Regex DivisionRegEx = new Regex(DivisionPattern);
        public static readonly Regex InvolutionRegEx = new Regex(InvolutionPattern);
        public static readonly Regex VariableRegEx = new Regex(VariablePattern);
        public static readonly Regex NonAlphanumericRegEx = new Regex(NonAlphanumericPattern);
        public static readonly Regex ArithmeticalSymbolRegEx = new Regex(ArithmeticalSymbolPattern);
        
        public static List<string> Parse(string input)
        {
            List<string> splittedMembers = new List<string>();
            input = input.Replace(" ", "");


            while (input.Length != 0)
            {
                if (NumberRegEx.IsMatch(input))
                {
                    string findedNumber = NumberRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (VariableRegEx.IsMatch(input))
                {
                    string findedVariable = VariableRegEx.Match(input).Value;
                    splittedMembers.Add(findedVariable);
                    input = input.Substring(findedVariable.Length, input.Length - findedVariable.Length);
                }
                else if (ArithmeticalSymbolRegEx.IsMatch(input))
                {
                    string findedSymbol = ArithmeticalSymbolRegEx.Match(input).Value;
                    splittedMembers.Add(findedSymbol);
                    input = input.Substring(findedSymbol.Length, input.Length - findedSymbol.Length);
                }
                else
                {
                    Console.WriteLine("Input string has incorrect values!");
                    return null;
                }
            }

            return splittedMembers;
        }
    }
}
