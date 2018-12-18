using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Tokenizer
{
    class StatementTokenizer
    {
        public Regex Regex;

        public StatementTokenizer(Regex symbolRegex)
        {
            Regex = symbolRegex;
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
    }
}
