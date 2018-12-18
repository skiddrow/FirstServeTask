using FirstTask.ExpressionParser.Parser;
using FirstTask.ProgramParser;
using FirstTask.ProgramParser.CodeLineParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    var lambda = LambdaBuilder.BuildFrom<Func<double, double, double>>("h/2*(2+((5+7,5/2)+1)-1)+a3");
            //    Console.WriteLine(lambda(12, 20));
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Incorrect input");
            //}

            //var pp = new ProgramInterpreter();
            //pp.Run();

            //var res = CodeLineTokenizer.Tokenize("let i := #5+3#");

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            ProgramInterpreter interpreter = new ProgramInterpreter();
            interpreter.Run();

            Console.ReadKey();
        }
    }
}