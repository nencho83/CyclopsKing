using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
/// <summary>
/// 
/// </summary>
public class Score
{
    private string playerName;
    private int playerScore;

    public Score(string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }

    public int PlayerScore
    {
        get { return this.playerScore; }
    }

    public string PlayerName
    {
        get { return this.playerName; }
    }
}