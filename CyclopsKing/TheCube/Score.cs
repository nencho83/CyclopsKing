using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
/// <summary>
/// 
/// </summary>
public  class Score
{
    public static List<string> SortScores(List<string> linesList)
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
        return linesList;

    }
}