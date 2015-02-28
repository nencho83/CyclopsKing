using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
/// <summary>
/// 
/// </summary>
class Score : IScore
{
    string scores = File.ReadAllText(@"..\..\test.csv");
    public static void SortScores(List<string> scoreList)
    {
        for (int i = 0; i < scoreList.Count - 1; i++)
        {
            int bestIndex = i;
            int bestScore = int.Parse(Regex.Match(scoreList[i], @"\d+").Value);

            for (int j = i + 1; j < scoreList.Count; j++)
            {
                int currentScore = int.Parse(Regex.Match(scoreList[j], @"\d+").Value);
                if (bestScore < currentScore)
                {
                    // Swap elements
                    string temporary = String.Copy(scoreList[j]);
                    scoreList[j] = scoreList[bestIndex];
                    scoreList[bestIndex] = temporary;
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
    public static int CalculateScore(int duration, int credits)
    {
        return duration * credits;
    }
}
