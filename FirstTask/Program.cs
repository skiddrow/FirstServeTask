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
            parser.Parse("12 + 6*5 -3^ 4 /y25+25");

            Console.ReadKey();
        }
    }
}