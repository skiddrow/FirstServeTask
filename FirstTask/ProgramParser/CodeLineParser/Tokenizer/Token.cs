using FirstTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Tokenizer
{
    class Token
    {
        public string Value { get; set; }
        public OperatorType TypeOfOperator { get; set; }

        public Token(string value, OperatorType typeOfOperator)
        {
            Value = value;
            TypeOfOperator = typeOfOperator;
        }
    }
}
