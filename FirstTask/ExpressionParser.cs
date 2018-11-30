using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask
{
    class ExpressionParser
    {
        const string NumberPattern = @"\d+(\.\d*)?";
        const string AdditionPattern = @"\+";
        const string SubtractionPattern = @"-";
        const string MultiplicationPattern = @"\*";
        const string DivisionPattern = @"/";
        const string InvolutionPattern = @"\^";
        const string VariablePattern = @"([A-Za-z][A-Za-z0-9]*)";

        public void Parse(string input)
        {
            input = input.Replace(" ", "");
            var splittedInput = input.Split(new char[] { '+', '-', '*', '/', '^' });
            List<IExpression> listOfObjects = new List<IExpression>();

            foreach (var item in splittedInput)
            {
                listOfObjects.Add(new NumberExpression(Double.Parse(item)));
                input = input.Remove(0, item.Length);

                if (input.Length != 0)
                {
                    var currentSymbol = input.Substring(0, 1);

                    Regex regEx = new Regex(MultiplicationPattern);

                    if (regEx.IsMatch(currentSymbol))
                    {
                        listOfObjects.Add(new MulExpression();
                    }

                    input = input.Remove(0, 1);
                }
            }
        }

        public IExpression GetExpressionTree(List<IExpression> inputList)
        {
            int i = 1;

            while (inputList.Count > 1)
            {
                if (inputList[i] is MulExpression)
                {
                    var mulExp = inputList[i] as MulExpression;
                    mulExp.leftExpression = inputList[i - 1];
                    mulExp.rightExpression = inputList[i + 1];
                    inputList[i] = mulExp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                }

                i += 2;
            }

            i = 1;

            while (inputList.Count > 1)
            {
                if (inputList[i] is DivExpression)
                {
                    var divExp = inputList[i] as DivExpression;
                    divExp.leftExpression = inputList[i - 1];
                    divExp.rightExpression = inputList[i + 1];
                    inputList[i] = divExp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                }

                i += 2;
            }

            i = 1;

            while (inputList.Count > 1)
            {
                if (inputList[i] is AddExpression)
                {
                    var addExp = inputList[i] as AddExpression;
                    addExp.leftExpression = inputList[i - 1];
                    addExp.rightExpression = inputList[i + 1];
                    inputList[i] = addExp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                }

                i += 2;
            }

            i = 1;

            while (inputList.Count > 1)
            {
                if (inputList[i] is SubExpression)
                {
                    var subExp = inputList[i] as SubExpression;
                    subExp.leftExpression = inputList[i - 1];
                    subExp.rightExpression = inputList[i + 1];
                    inputList[i] = subExp;
                    inputList.RemoveAt(i + 1);
                    inputList.RemoveAt(i - 1);
                }

                i += 2;
            }
        }

        public static void BuildFrom<T>()
        {

        }
    }
}
