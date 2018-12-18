using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.CodeLineParser.ExpressionGenerators.Contract
{
    abstract class Generator
    {
        protected List<string> CodeLine;

        public Generator(List<string> codeLine)
        {
            CodeLine = codeLine;
        }

        public abstract bool IsCorrectCodeLine();

        public abstract Expression GenerateExpression();
    }
}
