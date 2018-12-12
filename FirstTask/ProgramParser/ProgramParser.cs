using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class ProgramParser
    {
        private string FilePath;

        public ProgramParser()
        {
            FilePath = @"C:\SoftServe\IndividualTasks\Program.txt";
        }

        public void ParseProgram()
        {
            List<string> programStrings = FileReader.ReadFromFile(FilePath);

            if (programStrings == null)
            {
                Console.WriteLine("Program cannot be executed because of error in file reading!");

                return;
            }

            foreach (var line in programStrings)
            {
                
            }
        }
    }
}
