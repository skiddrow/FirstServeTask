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

            if (programStrings == null)
            {
                Console.WriteLine("Program cannot be executed because of error in file reading!");

                return;
            }

            foreach (var line in programStrings)
            {
                Console.WriteLine(line);
            }
        }

        //public static List<string> TokenizeLine(string line)
        //{
        //    var tokenizedLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //    return tokenizedLine.ToList();
        //}
    }
}
