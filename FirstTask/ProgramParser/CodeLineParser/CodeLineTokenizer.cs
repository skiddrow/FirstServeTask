using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser
{
    static class CodeLineTokenizer
    {
        public const string NumberLiteralPattern = @"^\d+(,\d*)?";
        public const string BoolLiteralPattern = @"^(true|false)";
        public const string StringLiteralPattern = "\".+\"";
        public const string ExpressionLiteralPattern = "#.+#";
        public const string VariablePattern = @"^([A-Za-z][A-Za-z0-9]*)";
        public const string ArithmeticalSymbolPattern = @"^(\+|-|\*|\/|\^)";
        //public const string AbsPattern = @"^Abs\(";

        //public static readonly Regex NumberRegEx = new Regex(NumberVariablePattern);
        //public static readonly Regex AdditionRegEx = new Regex(AdditionPattern);
        //public static readonly Regex SubtractionRegEx = new Regex(SubtractionPattern);
        //public static readonly Regex MultiplicationRegEx = new Regex(MultiplicationPattern);
        //public static readonly Regex DivisionRegEx = new Regex(DivisionPattern);
        //public static readonly Regex InvolutionRegEx = new Regex(InvolutionPattern);
        //public static readonly Regex VariableRegEx = new Regex(VariablePattern);
        //public static readonly Regex ArithmeticalSymbolRegEx = new Regex(ArithmeticalSymbolPattern);
        //public static readonly Regex OpeningBracketRegEx = new Regex(OpeningBracketPattern);
        //public static readonly Regex ClosingBracketRegEx = new Regex(ClosingBracketPattern);
        //public static readonly Regex AbsRegEx = new Regex(AbsPattern);
    }
}
