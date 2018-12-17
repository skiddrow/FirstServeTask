using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.ProgramParser
{
    class FileReader
    {
        public static List<string> ReadFromFile(string filePath)
        {
            var lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default))
                {
                    string line = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found!");

                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");

                return null;
            }

            return lines;
        }
    }
}
