using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Game
{
    public class Player
    {
        private string name;
        private int credits;
        private Category categoryType;
        private int bonusScore;
        private Coordinates coordinates;
        //private Hashtable passedMoves;

        //constructor with no arguments
        public Player()
        {
            this.name = SetName();
            this.credits = 18; //TheCube.theCube.Length * 2;
            this.categoryType = ChooseCategory();
            this.bonusScore = SetBonusScore();
            this.coordinates = new Coordinates(4, 4, 4); //(TheCube.theCube.Length / 2, TheCube.theCube.Length / 2, TheCube.theCube.Length / 2);
        }

        //constructor with arguments
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
                    name = value.Remove(30, (value.Length - 30));
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

        public string SetName()
        {
            string playerName = string.Empty;
            //allowed characters are lower and upper letters and underscores
            string allowCharacters = "^[a-zA-Z0-9_]*$";
            bool isValid;
            do
            {
                Console.WriteLine("Insert player name");
                playerName = Console.ReadLine();
                isValid = Regex.Match(playerName, allowCharacters).Success;
            } while (playerName.Length > 30 || !isValid);
            Console.Clear();
            return playerName;
        }

        public Category ChooseCategory()
        {
            Category category = Category.CSharpQuiz;
            int choice;
            do
            {
                Console.WriteLine("Choose category and the number");
                Console.WriteLine("1 -> C#");
                Console.WriteLine("2 -> Science");
                Console.WriteLine("3 -> Music/Films");
                Console.Write("Your choice is: ");
                choice = int.Parse(Console.ReadLine());
            } while (choice < 0 && choice > 4);
            switch (choice)
            {
                case 1:
                    category = Category.CSharpQuiz;
                    break;
                case 2:
                    category = Category.ScienceQuiz;
                    break;
                case 3:
                    category = Category.MusicFilmsQuiz;
                    break;
            }
            Console.Clear();
            return category;
        }

        public int SetBonusScore()
        {
            int duration = 30;
            //some operations with duration
            int bonusScore = duration;
            return bonusScore;
        }

        public override string ToString()
        {
            return string.Format("Player name: {0}\nCredits: {1}\nChosen category: {2}\nBonus Scores: {3}\nCoordinates {4},{5},{6}",
                                name, credits, categoryType, bonusScore, coordinates.X, coordinates.Y, coordinates.Z);
        }

        //this is for the test and must to be in another file
        //public static void Main()
        //{
        //    Player.Coordinates coordinates = new Player.Coordinates(3, 4, 5);
        //    Player player = new Player("Reni", 30, Player.Category.CSharpQuiz, 60, coordinates);
        //    Console.WriteLine(player.ToString());

        //    Console.WriteLine();

        //    Player anotherPlayer = new Player();
        //    Console.WriteLine(anotherPlayer.ToString());
        //}

    }
}