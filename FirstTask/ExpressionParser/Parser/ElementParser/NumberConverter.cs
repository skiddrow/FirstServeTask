using FirstTask.ExpressionParser.Elements;
using FirstTask.ExpressionParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser.Parser.ElementParser
{
    class NumberConverter : ExpressionConvertor
    {
        public NumberConverter(Regex symbolRegex)
        {
            Regex = symbolRegex;
            Function = () => new NumberElement(Double.Parse(ExpressionsParser.CurrentSymbol));
        }
    }
}
