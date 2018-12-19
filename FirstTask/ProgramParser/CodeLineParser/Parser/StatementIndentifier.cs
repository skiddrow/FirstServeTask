using FirstTask.Enums;
using FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.Parser
{
    class StatementIndentifier
    {
        public OperatorType TypeOfOperator { get; set; }
        protected Func<Generator> Function;

        public StatementIndentifier(OperatorType typeOfOperator, Func<Generator> function)
        {
            TypeOfOperator = typeOfOperator;
            Function = function;
        }

        public bool IsParsebleOperator(OperatorType inputOperator)
        {
            return TypeOfOperator == inputOperator;
        }

        //public Generator ExecuteFunction() { }
    }
}
