using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ExpressionParser
{
    public enum ExpressionType
    {
        Number = 1,
        Variable,
        Operation,
        Abs,
        OpeningBracket,
        ClosingBracket
    }
}
