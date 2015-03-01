using System;
using System.Collections;
using System.Text.RegularExpressions;


public class Player
{
    const int cubeSize = 9;

    private string name;
    private int credits;
    private Category categoryType;
    private int bonusScore;
    public Coordinates coordinates;
    public Hashtable passedMoves = new Hashtable();

    //constructor with no arguments
    public Player()
    {
        this.name = SetName();
        this.credits = cubeSize * 2;
        this.categoryType = ChooseCategory();
        this.bonusScore = SetBonusScore();
        this.coordinates = new Coordinates(cubeSize / 2, cubeSize / 2, cubeSize / 2);
        AddPassedMoves(coordinates.X, coordinates.Y, coordinates.Z);
    }
    //constructor with arguments
    public Player(string playerName, int playerCredits, Category categoryChoise, int playerBonusScore, Coordinates playerCoordinates, Hashtable playerPassedMoves)
    {
        Name = playerName;
        Credits = playerCredits;
        CategoryType = categoryChoise;
        BonusScore = playerBonusScore;
        coordinates = new Coordinates(playerCoordinates.X, playerCoordinates.Y, playerCoordinates.Z);
        AddPassedMoves(coordinates.X, coordinates.Y, coordinates.Z);
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
        bool isValid = true;
        do
        {
            Console.Clear();
            if (playerName.Length > 30 || !isValid) Console.WriteLine(@"Allowed characters : [a-zA-Z0-9_]");
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
        int choice = 1;
        do
        {
            if (choice < 1 || choice > 3) Console.WriteLine("\nNo Category under this number");
            Console.WriteLine("Choose category and the number");
            Console.WriteLine("1 -> C#");
            Console.WriteLine("2 -> Science");
            Console.WriteLine("3 -> Music/Films");
            Console.Write("Your choice is: ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error Handling stopped the game from breaking here!");
                choice = 0;
            }
        } while (choice < 1 || choice > 3);
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

    public int ChooseDirection()
    {
        int choice = 1;
        do
        {
            if (choice < 1 || choice > 6) Console.WriteLine("\nNo direction under this number");
            Console.WriteLine("Choose direction and the number");
            Console.WriteLine("1 -> Left");
            Console.WriteLine("2 -> Right");
            Console.WriteLine("3 -> Forward");
            Console.WriteLine("4 -> Backward");
            Console.WriteLine("5 -> Up");
            Console.WriteLine("6 -> Down");
            Console.Write("Your choice is: ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                //Console.Clear();
                Console.WriteLine("Error Handling stopped the game from breaking here!");
                choice = 0;
            }
        } while (choice < 1 || choice > 6);
        return choice;
    }

    public bool CheckForWall(int direction)
    {
        bool isWall = false;
        switch (direction)
        {
            //Left and Right is for the column(Y)
            case 1:
                if (TheCube.theCubeLabyrinth[coordinates.X, coordinates.Y - 1, coordinates.Z] == 1 && IsInCubeBoundary(coordinates.X, coordinates.Y - 1, coordinates.Z))
                {
                    Console.WriteLine("\nThere is a wall on that direction, choose another one");
                    isWall = true;
                    //direction = ChooseDirection();
                }
                break;
            case 2:
                if (TheCube.theCubeLabyrinth[coordinates.X, coordinates.Y + 1, coordinates.Z] == 1 && IsInCubeBoundary(coordinates.X, coordinates.Y + 1, coordinates.Z))
                {
                    Console.WriteLine("\nThere is a wall on that direction, choose another one");
                    isWall = true;
                    //direction = ChooseDirection();
                }
                break;
            //Forward and Backward is for depth(Z)
            case 3:
                if (TheCube.theCubeLabyrinth[coordinates.X, coordinates.Y, coordinates.Z - 1] == 1 && IsInCubeBoundary(coordinates.X, coordinates.Y, coordinates.Z - 1))
                {
                    Console.WriteLine("\nThere is a wall on that direction, choose another one");
                    isWall = true;
                    //direction = ChooseDirection();
                }
                break;
            case 4:
                if (TheCube.theCubeLabyrinth[coordinates.X, coordinates.Y, coordinates.Z + 1] == 1 && IsInCubeBoundary(coordinates.X, coordinates.Y, coordinates.Z + 1))
                {
                    Console.WriteLine("\nThere is a wall on that direction, choose another one");
                    isWall = true;
                    //direction = ChooseDirection();
                }
                break;
            //Up and Down is for row(X)
            case 5:
                if (TheCube.theCubeLabyrinth[coordinates.X - 1, coordinates.Y, coordinates.Z] == 1 && IsInCubeBoundary(coordinates.X - 1, coordinates.Y, coordinates.Z))
                {
                    Console.WriteLine("\nThere is a wall on that direction, choose another one");
                    isWall = true;
                    //direction = ChooseDirection();
                }
                break;
            case 6:
                if (TheCube.theCubeLabyrinth[coordinates.X + 1, coordinates.Y, coordinates.Z] == 1 && IsInCubeBoundary(coordinates.X + 1, coordinates.Y, coordinates.Z))
                {
                    Console.WriteLine("\nThere is a wall on that direction, choose another one");
                    isWall = true;
                    //direction = ChooseDirection();
                }
                break;
        }

        return isWall;
    }

    public void ChangeCoordinates(int direction, bool isCorrectAnswer)
    {
        //if player give correct anwer
        // isCorrectAnswer = true;
        if (isCorrectAnswer)
        {
            switch (direction)
            {
                case 1:
                    if (IsInCubeBoundary(coordinates.X, coordinates.Y - 1, coordinates.Z))
                    {
                        this.coordinates = new Coordinates(coordinates.X, coordinates.Y - 1, coordinates.Z);
                        AddPassedMoves(coordinates.X, coordinates.Y - 1, coordinates.Z);
                    }
                    break;
                case 2:
                    if (IsInCubeBoundary(coordinates.X, coordinates.Y + 1, coordinates.Z))
                    {
                        this.coordinates = new Coordinates(coordinates.X, coordinates.Y + 1, coordinates.Z);
                         AddPassedMoves(coordinates.X, coordinates.Y + 1, coordinates.Z);
                    }
                    break;
                case 3:
                    if (IsInCubeBoundary(coordinates.X, coordinates.Y, coordinates.Z - 1))
                    {
                        this.coordinates = new Coordinates(coordinates.X, coordinates.Y, coordinates.Z - 1);
                        AddPassedMoves(coordinates.X, coordinates.Y, coordinates.Z - 1);
                    }
                    break;
                case 4:
                    if (IsInCubeBoundary(coordinates.X, coordinates.Y, coordinates.Z + 1))
                    {
                        this.coordinates = new Coordinates(coordinates.X, coordinates.Y, coordinates.Z + 1);
                        AddPassedMoves(coordinates.X, coordinates.Y, coordinates.Z + 1);
                    }
                    break;
                case 5:
                    if (IsInCubeBoundary(coordinates.X - 1, coordinates.Y, coordinates.Z))
                    {
                        this.coordinates = new Coordinates(coordinates.X - 1, coordinates.Y, coordinates.Z);
                         AddPassedMoves(coordinates.X - 1, coordinates.Y, coordinates.Z);
                    }
                    break;
                case 6:
                    if (IsInCubeBoundary(coordinates.X + 1, coordinates.Y, coordinates.Z))
                    {
                        this.coordinates = new Coordinates(coordinates.X + 1, coordinates.Y, coordinates.Z);
                        AddPassedMoves(coordinates.X + 1, coordinates.Y, coordinates.Z);
                    }
                    break;
            }
            this.credits--;
        }
        else
        {
            this.credits--;
        }

    }

    public bool IsInCubeBoundary(int row, int column, int depth)
    {
        bool inBoundary = true;
        if ((row < 1 || row > cubeSize - 2 || column < 1 || column > cubeSize - 2 || depth < 1 || depth > cubeSize - 2))
        {
            inBoundary = false;
        }
        return inBoundary;
    }

    public void AddPassedMoves(int x, int y, int z)
    {
        string position = x + "," + y + "," + z;
        if(!this.passedMoves.Contains(position)) this.passedMoves.Add(position, true);
        //return passedMoves;
    }
    public override string ToString()
    {
        return string.Format("Player name: {0}\nCredits: {1}\nChosen category: {2}\nBonus Scores: {3}\nCoordinates {4},{5},{6}",
                            name, credits, categoryType, bonusScore, coordinates.X, coordinates.Y, coordinates.Z);
    }
}