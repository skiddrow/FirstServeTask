using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask
{
    class ExpressionParser
    {
        const string NumberPattern = @"^\d+(\.\d*)?";
        const string AdditionPattern = @"^\+";
        const string SubtractionPattern = @"^-";
        const string MultiplicationPattern = @"^\*";
        const string DivisionPattern = @"^/";
        const string InvolutionPattern = @"^\^";
        const string VariablePattern = @"^([A-Za-z][A-Za-z0-9]*)";
        Regex numberRegEx = new Regex(NumberPattern);
        Regex additionRegEx = new Regex(AdditionPattern);
        Regex subtractionRegEx = new Regex(SubtractionPattern);
        Regex multiplicationRegEx = new Regex(MultiplicationPattern);
        Regex divisionRegEx = new Regex(DivisionPattern);
        Regex involutionRegEx = new Regex(InvolutionPattern);
        Regex variableRegEx = new Regex(VariablePattern);

        public List<string> Parse(string input)
        {
            List<string> splittedMembers = new List<string>();
            input = input.Replace(" ", "");


            while (input.Length != 0)
            {
                if (numberRegEx.IsMatch(input))
                {
                    string findedNumber = numberRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (additionRegEx.IsMatch(input))
                {
                    string findedNumber = additionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (subtractionRegEx.IsMatch(input))
                {
                    string findedNumber = subtractionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (multiplicationRegEx.IsMatch(input))
                {
                    string findedNumber = multiplicationRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (divisionRegEx.IsMatch(input))
                {
                    string findedNumber = divisionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (involutionRegEx.IsMatch(input))
                {
                    string findedNumber = involutionRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else if (variableRegEx.IsMatch(input))
                {
                    string findedNumber = variableRegEx.Match(input).Value;
                    splittedMembers.Add(findedNumber);
                    input = input.Substring(findedNumber.Length, input.Length - findedNumber.Length);
                }
                else
                {
                    Console.WriteLine("Input string has incorrect values!");
                    return null;
                }
            }

            //foreach (var item in splittedMembers)
            //{
            //    Console.WriteLine(item);
            //}

            return splittedMembers;
        }

        public List<IExpression> ConvertStringsToExpressions(List<string> inputMembers)
        {
            List<IExpression> membersExpressions = new List<IExpression>();

            foreach (var member in inputMembers)
            {
                if (numberRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new NumberExpression(Double.Parse(member)));
                }
                else if (variableRegEx.IsMatch(member))
                {
                    // ДОДЕЛАТЬ
                    membersExpressions.Add(new NumberExpression(Double.Parse(member)));
                }
                else if (additionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new AddExpression());
                }
                else if (subtractionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new SubExpression());
                }
                else if (multiplicationRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new MulExpression());
                }
                else if (divisionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new DivExpression());
                }
                else if (involutionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new InvolutionExpression());
                }
            }

            return membersExpressions;
        }

        public IExpression GetExpressionTree(List<IExpression> inputList)
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
                if (inputList[i] is MulExpression)
                {
                    var mulExp = inputList[i] as MulExpression;
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
                if (inputList[i] is DivExpression)
                {
                    var mulExp = inputList[i] as DivExpression;
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
                if (inputList[i] is AddExpression)
                {
                    var mulExp = inputList[i] as AddExpression;
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
                if (inputList[i] is SubExpression)
                {
                    var mulExp = inputList[i] as SubExpression;
                    mulExp.leftExpression = inputList[i - 1];
                    mulExp.rightExpression = inputList[i + 1];
                    inputList[i] = mulExp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                    i -= 2;
                    n -= 2;
                }
            }

            return null;
        }

        public static void BuildFrom<T>(string formula)
        {
            //Expression.Lambda<T>()
        }
    }
}
