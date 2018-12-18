using FirstTask.Enums;
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
        public ElementType ExpressionType;

        public SymbolParser(Regex symbolRegex, ElementType expressionType)
        {
            Regex = symbolRegex;
            ExpressionType = expressionType;
        }

        public bool IsParsebleSymbol(string input)
        {
            return Regex.IsMatch(input);
        }

        public string GetMatch(string input)
        {
            var match = Regex.Match(input).Value;

            return match;
        }

        public void CutString(ref string input, string match)
        {
            input = input.Substring(match.Length, input.Length - match.Length);
        }

        public ElementType GetExpressionType()
        {
            return ExpressionType;
        }
    }
}
