using FirstTask.ProgramParser.CodeLineParser.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Tokenizer
{
    class StatementTokenizer : BaseRecognizer
    {
        protected Func<string, Token> Function;

        public StatementTokenizer(Regex symbolRegex, Func<string, Token> function)
            : base(symbolRegex)
        {
            Function = function;
        }

        public Token ExecuteFunction(string statement)
        {
            if (Function != null)
            {
                return Function(statement);
            }
            else
            {
                return null;
            }

        }
    }
}
