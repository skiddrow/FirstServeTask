using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Parser.ElementParser
{
    class ExpressionConvertor
    {
        public Func<IBasicElement> Function;
        public Regex Regex;

        public ExpressionConvertor() { }

        public ExpressionConvertor(Regex symbolRegex, Func<IBasicElement> function)
        {
            Regex = symbolRegex;
            Function = function;
        }

        public bool IsParsebleSymbol(string input)
        {
            return Regex.IsMatch(input);
        }
    }
}
