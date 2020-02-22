using System.Collections.Generic;
using System.IO;

namespace Payslip_Round_2.IO
{
    public class CsvReaderWriter
    {
        public static string[] ReadLines(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            return lines;
        }
        
        public static void WriteLines(string filename, List<string> lines)
        {
            File.WriteAllLines(filename, lines);
        }
    }
}