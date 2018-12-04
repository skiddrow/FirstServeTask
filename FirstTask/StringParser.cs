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
                else if (AdditionRegEx.IsMatch(input))
                {
                    string findedNumber = AdditionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (SubtractionRegEx.IsMatch(input))
                {
                    string findedNumber = SubtractionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (MultiplicationRegEx.IsMatch(input))
                {
                    string findedNumber = MultiplicationRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (DivisionRegEx.IsMatch(input))
                {
                    string findedNumber = DivisionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (InvolutionRegEx.IsMatch(input))
                {
                    string findedNumber = InvolutionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (VariableRegEx.IsMatch(input))
                {
                    string findedNumber = VariableRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
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
