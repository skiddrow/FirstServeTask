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
        public static List<ParameterExpression> Parameters;
        public static Dictionary<string, ParameterExpression> NamedParameters;
        public static BinaryExpression Assign = null;

        private string _filePath;

        static ProgramInterpreter()
        {
            Parameters = new List<ParameterExpression>();
            NamedParameters = new Dictionary<string, ParameterExpression>();
        }

        public ProgramInterpreter()
        {
            _filePath = @"C:\SoftServe\IndividualTasks\Program.txt";
        }

        public void Run()
        {
            var programStrings = FileReader.ReadFromFile(_filePath);
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

            var block = Expression.Block(Parameters.ToArray(), expressions.ToArray());
            //var block = Expression.Block(new ParameterExpression[] { Parameters[0] }, Assign, expressions[0]);

            Expression.Lambda<Action>(block).Compile().DynamicInvoke();

            //Expression.Lambda<Action>(block).Compile().DynamicInvoke();
            //res();
        }
    }
}
