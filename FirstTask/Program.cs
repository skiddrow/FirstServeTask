using FirstTask.ExpressionParser.Parser;
using FirstTask.ProgramParser;
using FirstTask.ProgramParser.CodeLineParser;
using FirstTask.ProgramParser.CodeLineParser.Tokenizer;
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

            //var res = CodeLineTokenizer.Tokenize("out i");

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Value);
            //    Console.WriteLine(item.TypeOfOperator);
            //    Console.WriteLine();
            //}

            ProgramInterpreter interpreter = new ProgramInterpreter();
            interpreter.Run();


            //var method = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            //var variable = Expression.Parameter(typeof(string), "a");
            //var assign = Expression.Assign(variable, Expression.Constant(42.ToString()));
            //var e = Expression.Call(null, method, variable);
            //var b = Expression.Block(new[] { variable }, assign, e);
            ////Console.WriteLine(b);
            //foreach (var a in b.Expressions)
            //    Console.WriteLine(a);
            //var lambda = Expression.Lambda<Action>(b);
            //lambda.Compile().DynamicInvoke();

            Console.ReadKey();
        }
    }
}