using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/// <summary>
/// 
/// </summary>
class Score : IScore
{
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
}
