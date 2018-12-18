using FirstTask.ProgramParser.CodeLineParser;
using FirstTask.ProgramParser.CodeLineParser.Parser;
using FirstTask.ProgramParser.CodeLineParser.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser
{
    class ProgramInterpreter
    {
        private string FilePath;

        public ProgramInterpreter()
        {
            FilePath = @"C:\SoftServe\IndividualTasks\Program.txt";
        }

        public void Run()
        {
            var programStrings = FileReader.ReadFromFile(FilePath);
            var expressions = new List<Expression>();

            if (programStrings == null)
            {
                Console.WriteLine("Program cannot be executed because of error in file reading!");

                return;
            }

            foreach (var line in programStrings)
            {
                var tokenizedLine = CodeLineTokenizer.Tokenize(line);

                if (tokenizedLine == null)
                {
                    Console.WriteLine("Error!");

                    return;
                }

                var interpretedLine = LineParser.Parse(tokenizedLine);

                if (interpretedLine == null)
                {
                    Console.WriteLine("Error!");

                    return;
                }

                expressions.Add(interpretedLine);
            }

            var block = Expression.Block(expressions);

            Expression.Invoke(block);
        }
    }
}
