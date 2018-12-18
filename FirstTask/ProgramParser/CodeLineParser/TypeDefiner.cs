using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser
{
    class TypeDefiner : WordParser
    {
        public Func<Type> Function;

        public TypeDefiner(Regex symbolRegex, Func<Type> function)
            : base(symbolRegex)
        {
            Function = function;
        }
    }
}
