using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parser.ParseStringAndCompute("2+3-1");

            //ExpressionParser parser = new ExpressionParser();
            //var a = parser.Parse("12 + 6*5 -3^ 4+25");
            //parser.BuildFrom("12 + 6*5 -3^ 4+25", null);
            //Dictionary<string, double> vars = new Dictionary<string, double>();
            //vars.Add("y", 3);
            //vars.Add("x", 2);
            //parser.BuildFrom("2 ^ x ^ y", vars);

            //IExpression addex1 = new AddExpression(new NumberExpression(1), new NumberExpression(1));
            //IExpression addex2 = new AddExpression(new NumberExpression(2), new NumberExpression(2));
            //Expression addex3 = new AddExpression(addex1, addex2).Compute();
            //LambdaExpression lEx = Expression.Lambda(addex3);
            //var lambda = (Func<double>)lEx.Compile();
            //Console.WriteLine(lambda());

            //var a = StringParser.Parse("12 + 6*5 -3^ 4+25");
            //Console.WriteLine(StringParser.IsCorrectExpression(a));
            
            //var res = (Func<double,double,double>)LambdaBuilder.BuildFrom<Func<double,double,double>>("y + 6*5 -3^ 4+h");
            var res = LambdaBuilder.BuildFrom<Func<double, double, double>>("y + 6*5 -3^ 4+h");
            Console.WriteLine(res(12,25));
            Console.ReadKey();
        }
    }
}