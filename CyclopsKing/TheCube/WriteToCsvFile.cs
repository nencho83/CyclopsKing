using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace team
{
    class WriteToCsvFile
    {
        static void Main(string[] args)
        {}
             public static void WriteToCSV(List<string> lines, string path)
        {
            StreamWriter writer = new StreamWriter(@path);
            using (writer)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i < lines.Count - 1)
                        writer.WriteLine(lines[i]);
                    else
                        writer.Write(lines[i]);
                }
            }
        }
        

    }
}
