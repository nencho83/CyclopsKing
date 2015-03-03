using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
/// <summary>
/// 
/// </summary>
public  class Score
{
    public static void SortScores(List<string> linesList)
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
         StreamWriter writer = new StreamWriter(@"..\..\scores.csv");
            using (writer)
            {
                for (int i = 0; i <linesList.Count; i++)
                {
                    if (i < linesList.Count - 1)
                        writer.WriteLine(linesList[i]);
                    else
                        writer.Write(linesList[i]);
                }
            }
            writer.Close();
    
    }
        public static void WriteToCSV(List<string> lines, string path)
        {
            StreamWriter writer = new StreamWriter(@path);
            using (writer)
            {
                for (int i = 0; i <lines.Count; i++)
                {
                    if (i < lines.Count - 1)
                        writer.WriteLine(lines[i]);
                    else
                        writer.Write(lines[i]);
                }
            }
        }
}
