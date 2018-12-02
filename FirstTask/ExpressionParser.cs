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
        const string NonAlphanumericPattern = @"^\W";
        Regex numberRegEx = new Regex(NumberPattern);
        Regex additionRegEx = new Regex(AdditionPattern);
        Regex subtractionRegEx = new Regex(SubtractionPattern);
        Regex multiplicationRegEx = new Regex(MultiplicationPattern);
        Regex divisionRegEx = new Regex(DivisionPattern);
        Regex involutionRegEx = new Regex(InvolutionPattern);
        Regex variableRegEx = new Regex(VariablePattern);
        Regex nonAlphanumericRegEx = new Regex(NonAlphanumericPattern);

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

            return splittedMembers;
        }

        public bool IsCorrectExpression(List<string> expression)
        {
            if (expression == null)
            {
                return false;
            }

            int expressionLength = expression.Count;

            if ((!numberRegEx.IsMatch(expression[0]) && !variableRegEx.IsMatch(expression[0])) || (!numberRegEx.IsMatch(expression[expressionLength - 1]) && !variableRegEx.IsMatch(expression[expressionLength - 1])))
            {
                return false;
            }

            for (int i = 0; i < expressionLength - 1; i++)
            {
                //if (!((numberRegEx.IsMatch(expression[i]) || variableRegEx.IsMatch(expression[i])) && nonAlphanumericRegEx.IsMatch(expression[i + 1])))
                if (nonAlphanumericRegEx.IsMatch(expression[i]) && nonAlphanumericRegEx.IsMatch(expression[i + 1]))
                {
                    return false;
                }
            }

            return true;
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

        public void BuildFrom<T>(string formula)
        {
            var parsedString = Parse(formula);

            if (!IsCorrectExpression(parsedString))
            {
                Console.WriteLine("Input expression has incorrect format");

                return;
            }

            var expressionsList = ConvertStringsToExpressions(parsedString);
            var expressionTree = GetExpressionTree(expressionsList);

            var result = expressionTree.Compute();
            Console.WriteLine(result);
            var a = 5 + 3;
            //var fuction = Expression.Lambda<T>(
            //    Expression.
            //    )
        }
    }
}
