using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Parser
{
    class SymbolParser
    {
        public Regex Regex;
        public ExpressionType ExpressionType;

        public SymbolParser(Regex symbolRegex, ExpressionType expressionType)
        {
            Regex = symbolRegex;
            ExpressionType = expressionType;
        }

        public bool IsParsebleSymbol(string input)
        {
            return Regex.IsMatch(input);
        }

        public string GetMatchAndSubstring(ref string input)
        {
            var match = Regex.Match(input).Value;
            input = input.Substring(match.Length, input.Length - match.Length);

            return match;
        }

        public ExpressionType GetExpressionType()
        {
            return ExpressionType;
        }
    }
}
