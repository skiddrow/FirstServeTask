using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask
{
    class SymbolParser
    {
        public Func<IBasicExpression> Del;
        public Regex Regex;

        public SymbolParser(Regex symbolRegex, Func<IBasicExpression> del)
        {
            Regex = symbolRegex;
            Del = del;
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
    }
}
