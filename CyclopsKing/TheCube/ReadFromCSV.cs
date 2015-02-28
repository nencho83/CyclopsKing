using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadFromCSV
{
    class ReadFromCSV
    {
        static void Main(string[] args)
        {
            // Read from CSV
            string scores = File.ReadAllText(@"..\..\test.csv");
        }
    }
}
