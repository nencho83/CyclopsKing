using System;
using System.Collections.Generic;

public class Player
{
    private string name;
    private int credits;
    private Category categoryType;
    private int bonusScore;
    private Coordinates coordinates;
    private Category category;
    //private Hashtable passedMoves;

    public Player(string playerName, int playerCredits, Category categoryChoise, int playerBonusScore, Coordinates playerCoordinates)
    {
        Name = playerName;
        Credits = playerCredits;
        CategoryType = categoryChoise;
        BonusScore = playerBonusScore;
        coordinates = new Coordinates(playerCoordinates.X, playerCoordinates.Y, playerCoordinates.Z);
    }

    public struct Coordinates
    {
        private int x;
        private int y;
        private int z;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Z { get { return z; } }
        public Coordinates(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public enum Category { CSharpQuiz, ScienceQuiz, MusicFilmsQuiz };
    //use gefault properties
    public Category CategoryType
    { get; set; }

    //property that gets and sets the name
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value.Length > 30)
            {
                //some default value
                name = string.Empty;
            }
            else
            {
                name = value;
            }
        }
    }

    public int Credits
    {
        get
        {
            return credits;
        }
        set
        {
            if (value < 0)
            {
                //some default value
                credits = 0;
            }
            else
            {
                credits = value;
            }
        }
    }

    public int BonusScore
    {
        get
        {
            return bonusScore;
        }
        set
        {
            if (value < 0)
            {
                bonusScore = 0;
            }
            else
            {
                //bonus score is left duration
                bonusScore = value;
            }
        }
    }

    public override string ToString()
    {
        return string.Format("Player name: {0}, Credits: {1}, Chosen category: {2}, Bonus Scores: {3}, Coordinates {4},{5},{6}",
                            name, credits, categoryType, bonusScore, coordinates.X, coordinates.Y, coordinates.Z);
    }

    public static void Main()
    {
        Player.Coordinates coordinates = new Player.Coordinates(3, 4, 5);
        Player player = new Player("Reni", 30, Player.Category.CSharpQuiz, 60, coordinates);
        Console.WriteLine(player.ToString());
    }

}