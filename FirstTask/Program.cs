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
            #region
            //Parser.ParseStringAndCompute("2+3-1");

            //ExpressionParser parser = new ExpressionParser();
            //var a = parser.Parse("12 + 6*5 -3^ 4+25");

            //var res = LambdaBuilder.BuildFrom<Func<double, double, double>>("y + 6*5 -3^ 4+h");
            //Console.WriteLine(res(12, 25));

            //var res = LambdaBuilder.BuildFrom<Func<double, double, double>>("y + 6*5 -3^ 4+h");

            //if (res != null)
            //{
            //    Console.WriteLine(res(12, 25));
            //}
            #endregion

            //var listOfStrings = StringParser.IsBracketsOkay("h/2*(2+((5+7,5/2)+1)-1)+a3");
            var res = LambdaBuilder.BuildFrom<Func<double, double, double>>("h/2*(2+((5+7,5/2)+1)-1)+a3");
            Console.WriteLine(res(12, 20));
            var a = Math.Truncate(21 + 5.6 + Math.Pow(2, 50) - (2 - 10));
            //Console.WriteLine(listOfStrings);
            Console.ReadKey();
        }
    }
}