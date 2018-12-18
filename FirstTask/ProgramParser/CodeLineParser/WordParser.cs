using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser
{
    class WordParser
    {
        public Regex Regex;

        public WordParser(Regex symbolRegex)
        {
            Regex = symbolRegex;
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
