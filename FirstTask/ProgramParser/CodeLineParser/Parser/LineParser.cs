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
        public static Expression Parse(List<string> codeLine)
        {
            Generator generator = null;

            if (CodeLineTokenizer.LetRegEx.IsMatch(codeLine[0]))
            {
                generator = new VariableGenerator(codeLine, DefineExpressionType(codeLine[3]));
            }

            return generator.GenerateExpression();
        }
        
        public static Type DefineExpressionType(string expression)
        {
            var definers = new List<TypeDefiner>();

            definers.Add(new TypeDefiner(CodeLineTokenizer.NumberLiteralRegEx, () => typeof(double)));
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
