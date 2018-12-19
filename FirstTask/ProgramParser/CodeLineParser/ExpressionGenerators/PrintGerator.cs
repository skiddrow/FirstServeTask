using FirstTask.Enums;
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
    class PrintGerator : Generator
    {
        public PrintGerator(List<Token> codeLine)
            : base(codeLine)
        { }

        public override bool IsCorrectCodeLine()
        {
            if (CodeLine.Count != 2)
            {
                return false;
            }

            if (!CodeLine.Exists(token => token.TypeOfOperator == OperatorType.Variable))
            {
                return false;
            }

            if ((CodeLine.FindAll(token => token.TypeOfOperator == OperatorType.Out).Count > 1) ||
                (CodeLine.FindAll(token => token.TypeOfOperator == OperatorType.Variable).Count > 1))
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

            var valueToken = CodeLine.FirstOrDefault(token => token.TypeOfOperator != OperatorType.Out);

            if (string.IsNullOrEmpty(valueToken.Value))
            {
                return null;
            }

            var type = ProgramInterpreter.Parameters.FirstOrDefault(p => p.Name == valueToken.Value).Type;
            var expression = Expression.Call(
                null,
                typeof(Console).GetMethod("WriteLine", new Type[] { type }),
                ProgramInterpreter.NamedParameters.FirstOrDefault(p => p.Key == valueToken.Value).Value
                );

            return expression;
        }
    }
}
