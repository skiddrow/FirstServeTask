using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Tokenizer
{
    static class CodeLineTokenizer
    {
        public const string NumberLiteralPattern = @"\d+(,\d*)?";
        public const string BoolLiteralPattern = @"(true|false)";
        public const string StringLiteralPattern = "(\".+\")";
        public const string ExpressionLiteralPattern = "(#.+#)";
        public const string VariablePattern = @"([A-Za-z][A-Za-z0-9]*)";
        public const string OutPattern = KeyWords.Out;
        public const string LetPattern = KeyWords.Let + @"\s+([A-Za-z][A-Za-z0-9]*)\s*:=";
        public const string BeginPattern = @"^" + KeyWords.Begin;
        public const string EndPattern = @"^" + KeyWords.End;
        public const string AssignPattern = @"^" + KeyWords.Assign;

        public static readonly Regex NumberLiteralRegEx = new Regex(NumberLiteralPattern);
        public static readonly Regex BoolLiteralRegEx = new Regex(BoolLiteralPattern);
        public static readonly Regex StringLiteralRegEx = new Regex(StringLiteralPattern);
        public static readonly Regex ExpressionLiteralRegEx = new Regex(ExpressionLiteralPattern);
        public static readonly Regex VariableRegEx = new Regex(VariablePattern);
        public static readonly Regex OutRegEx = new Regex(OutPattern);
        public static readonly Regex LetRegEx = new Regex(LetPattern);
        public static readonly Regex BeginRegEx = new Regex(BeginPattern);
        public static readonly Regex EndRegEx = new Regex(EndPattern);
        public static readonly Regex AssignRegEx = new Regex(AssignPattern);

        public static List<string> Tokenize(string input)
        {
            var splittedMembers = new List<string>();
            var parsers = new List<StatementTokenizer>();

            parsers.Add(new StatementTokenizer(LetRegEx));
            parsers.Add(new StatementTokenizer(OutRegEx));
            parsers.Add(new StatementTokenizer(NumberLiteralRegEx));
            parsers.Add(new StatementTokenizer(BoolLiteralRegEx));
            parsers.Add(new StatementTokenizer(StringLiteralRegEx));
            parsers.Add(new StatementTokenizer(ExpressionLiteralRegEx));
            parsers.Add(new StatementTokenizer(VariableRegEx));

            while (input.Length != 0)
            {
                CutInitialSpaces(ref input);
                var currentParser = parsers.FirstOrDefault(p => p.IsParsebleSymbol(input));

                if (currentParser == null)
                {
                    return null;
                }

                var match = currentParser.GetMatch(input);
                currentParser.CutString(ref input, match);

                splittedMembers.Add(match);
            }

            return splittedMembers;
        }

        public static void CutInitialSpaces(ref string input)
        {
            while (input[0].ToString() == " ")
            {
                input = input.Remove(0, 1);
            }
        }
    }
}
