using System;
using System.Collections;
using System.Text.RegularExpressions;
/// <summary>
/// 
/// </summary>
public class Player : IPlayer
{
    private string nickname;
    private int credits;
    private int bonusScore;
    private Category category;
    private Coordinate position;
    public Hashtable visited = new Hashtable();

    public Player(string nickname, int credits, Category category, int bonusScore, Coordinate position)
    {
        this.nickname = nickname;
        this.credits = credits;
        this.category = category;
        this.bonusScore = bonusScore;
        this.position = position;
        MarkVisited(string.Format("{0},{1},{2}", position.Row, position.Column, position.Depth));
    }

    public string Nickname
    {
        get { return nickname; }
        set { nickname = value.Length > 30 ? value.Remove(30, (value.Length - 30)) : value; }
    }

    public int Credits
    {
        get { return this.credits; }
        set { this.credits = value < 0 ? 0 : value; }
    }

    public int BonusScore
    {
        get { return this.bonusScore; }
        set { this.bonusScore = value < 0 ? 0 : value; }
    }

    public Category Category
    {
        get { return this.category; }
        set { this.category = value; }
    }

    public Coordinate Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    public Direction ChooseDirection()
    {
        Direction cmd = Direction.UP;
        Console.WriteLine("Enter a direction:");

        bool isInvalidCommand = true;
        while (isInvalidCommand)
        {
            isInvalidCommand = false;
            switch (Console.ReadLine().ToLower())
            {
                case "up": cmd = Direction.UP; break;
                case "down": cmd = Direction.DOWN; break;
                case "left": cmd = Direction.LEFT; break;
                case "right": cmd = Direction.RIGHT; break;
                case "forward": cmd = Direction.FORWARD; break;
                case "backward": cmd = Direction.BACKWARD; break;

                default:
                    Console.WriteLine("There is no such direction! Please choose valid direction:");
                    isInvalidCommand = true;
                    break;
            }
        }

        return cmd;
    }

    public bool IsVisited(string position)
    {
        return this.visited.Contains(position);
    }

    public void MarkVisited(string position)
    {
        this.visited.Add(position, true);
    }

    public override string ToString()
    {
        return string.Format("{0}|{1}|{2}|{3}", nickname, credits, category, bonusScore);
    }

    public struct Coordinate
    {
        private int row;
        private int column;
        private int depth;

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }
        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        }
        public int Depth
        {
            get { return this.depth; }
            set { this.depth = value; }
        }
        public Coordinate(int row, int column, int depth)
        {
            this.row = row;
            this.column = column;
            this.depth = depth;
        }
    }
}