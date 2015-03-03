using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
/// <summary>
/// 
/// </summary>
public static class Score
{
//  string scores = File.ReadAllText(@"..\..\Scores.csv");
 
          
//            List<string> lines = scores
//                .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
//                .ToList();
 
 
               //public static void OutOfCredits(string nickname, int credits)
    //{
    //    string nameAndScore = nickname + ", " + credits;
    //    File.AppendAllText(@".\..\..\Test.csv", nameAndScore + Environment.NewLine);
    //}
            //SortScores(lines);
 
            //// Write scores to CSV
            //WriteToCSV(lines, @"..\..\test.csv");
       
 
        private static void SortScores(List<string> linesList)
        {
            for (int i = 0; i < linesList.Count - 1; i++)
            {
                int bestIndex = i;
                int bestScore = int.Parse(Regex.Match(linesList[i], @"\d+").Value);
 
                for (int j = i + 1; j < linesList.Count; j++)
                {
                    int currentScore = int.Parse(Regex.Match(linesList[j], @"\d+").Value);
                    if (bestScore < currentScore)
                    {
                        // Swap elements
                        string temporary = String.Copy(linesList[j]);
                        linesList[j] = linesList[bestIndex];
                        linesList[bestIndex] = temporary;
                    }
                }
            }
        }
       
     
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
