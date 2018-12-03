using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parser.ParseStringAndCompute("2+3-1");

            ExpressionParser parser = new ExpressionParser();
            //var a = parser.Parse("12 + 6*5 -3^ 4+25");
            parser.BuildFrom("12 + 6*5 -3^ 4+25", null);
            //Dictionary<string, double> vars = new Dictionary<string, double>();
            //vars.Add("y", 3);
            //vars.Add("x", 2);
            //parser.BuildFrom("2 ^ x ^ y", vars);
            Console.ReadKey();
        }
    }
}