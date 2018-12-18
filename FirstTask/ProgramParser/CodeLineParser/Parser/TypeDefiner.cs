using FirstTask.ProgramParser.CodeLineParser.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Parser
{
    class TypeDefiner : StatementTokenizer
    {
        protected Func<Type> Function;

        public TypeDefiner(Regex symbolRegex, Func<Type> function)
            : base(symbolRegex)
        {
            Function = function;
        }

        public Type ExecuteFunc()
        {
            if (Function != null)
            {
                return Function();
            }
            else
            {
                return null;
            }
        }
    }
}
