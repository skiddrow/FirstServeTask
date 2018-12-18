using FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators.Contract;
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
        private Type TypeOfVariable;

        public VariableGenerator(List<string> codeLine, Type typeOfVariable)
            : base(codeLine)
        {
            TypeOfVariable = typeOfVariable;
        }

        public override bool IsCorrectCodeLine()
        {
            if (CodeLine.Count != 4)
            {
                return false;
            }

            if (!CodeLineTokenizer.VariableRegEx.IsMatch(CodeLine[1]))
            {
                return false;
            }

            if (!CodeLineTokenizer.AssignRegEx.IsMatch(CodeLine[2]))
            {
                return false;
            }

            if (CodeLineTokenizer.NumberLiteralRegEx.IsMatch(CodeLine[3]) &
                CodeLineTokenizer.BoolLiteralRegEx.IsMatch(CodeLine[3]) &
                CodeLineTokenizer.StringLiteralRegEx.IsMatch(CodeLine[3]) &
                CodeLineTokenizer.ExpressionLiteralRegEx.IsMatch(CodeLine[3]))
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

            string NameOfVariable = CodeLine[1];
            var variableExpression = Expression.Variable(TypeOfVariable, NameOfVariable);
            object variableValue = 0;

            if (TypeOfVariable.Name == "Double")
            {
                variableValue = Double.Parse(CodeLine[3]);
            }
            else if (TypeOfVariable.Name == "String")
            {
                variableValue = CodeLine[3].ToString();
            }
            else if (TypeOfVariable.Name == "Boolean")
            {
                variableValue = Boolean.Parse(CodeLine[3]);
            }

            var expression = Expression.Assign(variableExpression, Expression.Constant(variableValue));

            return expression;
        }
    }
}
