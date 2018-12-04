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
        private const string NumberPattern = @"^\d+(\.\d*)?";
        private const string AdditionPattern = @"^\+";
        private const string SubtractionPattern = @"^-";
        private const string MultiplicationPattern = @"^\*";
        private const string DivisionPattern = @"^/";
        private const string InvolutionPattern = @"^\^";
        private const string VariablePattern = @"^([A-Za-z][A-Za-z0-9]*)";
        private const string NonAlphanumericPattern = @"^\W";
        private Regex NumberRegEx = new Regex(NumberPattern);
        private Regex AdditionRegEx = new Regex(AdditionPattern);
        private Regex SubtractionRegEx = new Regex(SubtractionPattern);
        private Regex MultiplicationRegEx = new Regex(MultiplicationPattern);
        private Regex DivisionRegEx = new Regex(DivisionPattern);
        private Regex InvolutionRegEx = new Regex(InvolutionPattern);
        private Regex VariableRegEx = new Regex(VariablePattern);
        private Regex NonAlphanumericRegEx = new Regex(NonAlphanumericPattern);

        private List<string> Parse(string input)
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

        private bool IsCorrectExpression(List<string> expression)
        {
            if (expression == null)
            {
                return false;
            }

            int expressionLength = expression.Count;
            bool isFirstMemeberIsNumberOrVariable = !NumberRegEx.IsMatch(expression[0]) && !VariableRegEx.IsMatch(expression[0]);
            bool isLastMemeberIsNumberOrVariable = !NumberRegEx.IsMatch(expression[expressionLength - 1]) && !VariableRegEx.IsMatch(expression[expressionLength - 1]);

            if (isFirstMemeberIsNumberOrVariable || isLastMemeberIsNumberOrVariable)
            {
                return false;
            }

            for (int i = 0; i < expressionLength - 1; i++)
            {
                //if (!((numberRegEx.IsMatch(expression[i]) || variableRegEx.IsMatch(expression[i])) && nonAlphanumericRegEx.IsMatch(expression[i + 1])))
                if (NonAlphanumericRegEx.IsMatch(expression[i]) && NonAlphanumericRegEx.IsMatch(expression[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private List<IExpression> ConvertStringsToExpressions(List<string> inputMembers)
        {
            List<IExpression> membersExpressions = new List<IExpression>();

            foreach (var member in inputMembers)
            {
                if (NumberRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new NumberExpression(Double.Parse(member)));
                }
                else if (VariableRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new VariableExpression(member));
                }
                else if (AdditionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new AddExpression());
                }
                else if (SubtractionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new SubExpression());
                }
                else if (MultiplicationRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new MulExpression());
                }
                else if (DivisionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new DivExpression());
                }
                else if (InvolutionRegEx.IsMatch(member))
                {
                    membersExpressions.Add(new InvolutionExpression());
                }
            }

            return membersExpressions;
        }

        private IExpression GetExpressionTree(List<IExpression> inputList)
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

        public void BuildFrom(string formula, Dictionary<string, double> variables)
        {
            var parsedString = Parse(formula);

            if (!IsCorrectExpression(parsedString))
            {
                Console.WriteLine("Input expression has incorrect format");

                return;
            }

            var expressionsList = ConvertStringsToExpressions(parsedString);
            var expressionTree = GetExpressionTree(expressionsList);

            if (variables != null)
            {
                SetContextVariables(variables);
            }

            var result = expressionTree.Compute();
            Console.WriteLine(result);
        }

        //public T BuildFrom<T>(string formula) where T : class
        //{
        //    var parsedString = Parse(formula);

        //    if (!IsCorrectExpression(parsedString))
        //    {
        //        Console.WriteLine("Input expression has incorrect format");

        //        return null;
        //    }

        //    var expressionsList = ConvertStringsToExpressions(parsedString);
        //    var expressionTree = GetExpressionTree(expressionsList);
        //    //var result = expressionTree.Compute(Cntx);
        //    var param = Expression.Parameter(typeof(T));
        //    var callExpression = Expression.Call(typeof(ExpressionParser).GetMethod("GetExpressionTree"), Expression.Constant(Cntx));


        //    return Expression.Lambda<T>(Expression.Invoke(callExpression, param)).Compile();
        //}

        private void SetContextVariables(Dictionary<string, double> variables)
        {
            foreach (var variable in variables)
            {
                //Cntx.AddVar(variable.Key, variable.Value);
            }
        }
    }
}
