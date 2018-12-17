using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser.WordParser
{
    abstract class CommandParser
    {
        public Regex CommandName;
        public List<string> CodeLine;

        public CommandParser()
        { }

        public CommandParser(string commandNamePattern, List<string> codeLine)
        {
            CommandName = new Regex(commandNamePattern);
            CodeLine = codeLine;
        }

        public bool IsCurrentCommand(string input)
        {
            return CommandName.IsMatch(input);
        }

        public abstract Expression GetExpression();

        public abstract bool IsCorrectExpression();
    }
}
