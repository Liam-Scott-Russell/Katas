using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Payslip_Round_2
{
    public class CsvReaderWriter
    {
        public static string[] ReadLines(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            return lines;
        }
    }
}