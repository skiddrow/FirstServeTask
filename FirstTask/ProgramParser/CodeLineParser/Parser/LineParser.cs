using FirstTask.Enums;
using FirstTask.ExpressionParser.Interfaces;
using FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators;
using FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators.Contract;
using FirstTask.ProgramParser.CodeLineParser.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Parser
{
    static class LineParser
    {
        public static OperatorType TypeOfExpression { get; set; }

        public static Expression Parse(List<Token> codeLine)
        {
            Generator generator = null;

            if (codeLine.Exists(token => token.TypeOfOperator == OperatorType.Let))
            {
                generator = new VariableGenerator(codeLine);
            }
            else if (codeLine.Exists(token => token.TypeOfOperator == OperatorType.Out))
            {
                generator = new PrintGerator(codeLine);
            }

            return generator.GenerateExpression();
        }

        public static Type DefineExpressionType(string expression)
        {
            var definers = new List<TypeDefiner>();

            definers.Add(new TypeDefiner(CodeLineTokenizer.NumberLiteralRegEx, () => typeof(float)));
            definers.Add(new TypeDefiner(CodeLineTokenizer.BoolLiteralRegEx, () => typeof(bool)));
            definers.Add(new TypeDefiner(CodeLineTokenizer.StringLiteralRegEx, () => typeof(string)));
            definers.Add(new TypeDefiner(CodeLineTokenizer.ExpressionLiteralRegEx, () => typeof(double)));

            var currentDefiner = definers.FirstOrDefault(p => p.IsParsebleSymbol(expression));

            if (currentDefiner == null)
            {
                return null;
            }

            return currentDefiner.ExecuteFunc();
        }
    }
}
