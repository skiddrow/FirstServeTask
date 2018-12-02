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
            var a = parser.Parse("12 + 6*5 -3^ 4+25");
            parser.BuildFrom<int>("12 + 6*5 -3^ 4/3+25/2");
            Console.ReadKey();
        }
    }
}