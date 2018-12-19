using FirstTask.Enums;
using FirstTask.ExpressionParser.Parser;
using FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators.Contract;
using FirstTask.ProgramParser.CodeLineParser.Parser;
using FirstTask.ProgramParser.CodeLineParser.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators
{
    class VariableGenerator : Generator
    {
        private Type _typeOfVariable;

        public VariableGenerator(List<Token> codeLine)
            : base(codeLine)
        { }

        public override bool IsCorrectCodeLine()
        {
            if (CodeLine.Count != 2)
            {
                return false;
            }

            // Is code line contains expression which can be assigned to a variable
            if (!CodeLine.Exists(token => token.TypeOfOperator == OperatorType.NumbetLiteral) &&
                !CodeLine.Exists(token => token.TypeOfOperator == OperatorType.BoolLiteral) &&
                !CodeLine.Exists(token => token.TypeOfOperator == OperatorType.StringLiteral) &&
                !CodeLine.Exists(token => token.TypeOfOperator == OperatorType.ExpressionLiteral))
            {
                return false;
            }

            if (CodeLine.FindAll(token => token.TypeOfOperator == OperatorType.Let).Count > 1)
            {
                return false;
            }

            return true;
        }

        public override Expression GenerateExpression()
        {
            if (!IsCorrectCodeLine())
            {
                return null;
            }

            var letToken = CodeLine.FirstOrDefault(token => token.TypeOfOperator == OperatorType.Let);
            letToken.Value = letToken.Value.Replace("let", "");
            var nameOfVariable = StringTokenizer.VariableRegEx.Match(letToken.Value).Value;
            var valueToken = CodeLine.FirstOrDefault(token => token.TypeOfOperator != OperatorType.Let);
            string variableValue = valueToken.Value;
            _typeOfVariable = LineParser.DefineExpressionType(variableValue);
            var variableExpression = Expression.Variable(_typeOfVariable, nameOfVariable);
            ProgramInterpreter.Parameters.Add(variableExpression);
            ProgramInterpreter.NamedParameters.Add(nameOfVariable, variableExpression);
            object variableParsedValue = 0;
            
            if (_typeOfVariable.Name == "Single")
            {
                variableParsedValue = Single.Parse(variableValue);
            }
            else if (_typeOfVariable.Name == "String")
            {
                variableParsedValue = variableValue.Substring(1, variableValue.Length - 2);
            }
            else if (_typeOfVariable.Name == "Boolean")
            {
                variableParsedValue = Boolean.Parse(variableValue);
            }
            else if (_typeOfVariable.Name == "Double")
            {
                var exp = LambdaBuilder.GetExpression(variableValue.Substring(1, variableValue.Length - 2));
                variableParsedValue = Expression.Lambda<Func<double>>(exp, new ParameterExpression[] { }).Compile().DynamicInvoke();

                if ((double)variableParsedValue == double.NaN)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            var expression = Expression.Assign(variableExpression, Expression.Constant(variableParsedValue));
            ProgramInterpreter.Assign = expression;
            //var expression = Expression.Block(new ParameterExpression[] { variableExpression }, expression, expression);

            return expression;
        }
    }
}
