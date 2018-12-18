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
        public const string StringLiteralPattern = "^(\".+\")";
        public const string ExpressionLiteralPattern = "^(#.+#)";
        public const string VariablePattern = @"^([A-Za-z][A-Za-z0-9]*)";
        public const string OutPattern = @"^" + @KeyWords.Out;
        public const string LetPattern = @"^" + @KeyWords.Let;
        public const string BeginPattern = @"^" + @KeyWords.Begin;
        public const string EndPattern = @"^" + @KeyWords.End;
        public const string AssignPattern = @"^" + @KeyWords.Assign;
        //public const string LoopPattern = @"^" + @KeyWords.Loop;

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
        //public static readonly Regex LoopRegEx = new Regex(LoopPattern);

        public static List<string> Tokenize(string input)
        {
            var splittedMembers = new List<string>();
            var parsers = new List<WordParser>();

            parsers.Add(new WordParser(NumberLiteralRegEx));
            parsers.Add(new WordParser(BoolLiteralRegEx));
            parsers.Add(new WordParser(StringLiteralRegEx));
            parsers.Add(new WordParser(ExpressionLiteralRegEx));
            parsers.Add(new WordParser(VariableRegEx));
            parsers.Add(new WordParser(OutRegEx));
            parsers.Add(new WordParser(LetRegEx));
            parsers.Add(new WordParser(BeginRegEx));
            parsers.Add(new WordParser(EndRegEx));
            parsers.Add(new WordParser(AssignRegEx));

            while (input.Length != 0)
            {
                CutInitialSpaces(ref input);
                var currentParser = parsers.FirstOrDefault(p => p.IsParsebleSymbol(input));

                if (currentParser == null)
                {
                    return null;
                }

                var match = currentParser.GetMatchAndSubstring(ref input);
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
