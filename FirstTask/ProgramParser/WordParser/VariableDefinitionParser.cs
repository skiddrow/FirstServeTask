using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.WordParser
{
    class VariableDefinitionParser : CommandParser
    {
        public VariableDefinitionParser(string commandNamePattern, List<string> codeLine)
            : base(commandNamePattern, codeLine) 
        { }

        public override Expression GetExpression()
        {
            throw new NotImplementedException();
        }

        public override bool IsCorrectExpression()
        {
            throw new NotImplementedException();
        }
    }
}
