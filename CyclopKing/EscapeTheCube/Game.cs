using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Game
{
    private const string INSTRUCTIONS = @".\..\..\Instructions.txt";
    private const string HIGHSCORES = @".\..\..\Scores.csv";

    private bool isGameOn;
    private int previousSelectedOption;
    private int[, ,] labyrinth;
    private Player player;
    private Menu menu;
    private List<Challenge> challenges = new List<Challenge>();

    public Game(int cubeSize)
    {
        this.isGameOn = false;
        this.previousSelectedOption = 0;
        this.labyrinth = Utils.Generate3DLabyrinth(cubeSize);
        this.menu = new Menu(new string[] { "New Game", "Instructions", "High Scores", "Exit" });

        menu.Show(previousSelectedOption);
        GameOn();
    }

    private void Start()
    {
        isGameOn = true;
        int center = labyrinth.GetLength(0) / 2;
        if (player == null)
        {
            this.player = CreatePlayer(center);
        }
        else
        {
            this.player.Position = new Player.Coordinate(center, center, center);
        }

        string line;
        using (StreamReader reader = new StreamReader(@".\..\..\" + player.Category + "_Questions.csv"))
        {
            while ((line = reader.ReadLine()) != null)
            {
                Challenge challenge = Utils.ExtractChallenge(line.Split('|'));
                challenges.Add(challenge);
            }
        }

        Play();
    }

    private static Player CreatePlayer(int middle)
    {
        Console.WriteLine("Enter a nickname:");
        string nickname = Console.ReadLine();

        return new Player(nickname, 20, Utils.ChooseCategory(), 0, new Player.Coordinate(middle, middle, middle));
    }

    private void Reset()
    {
        Start();
    }

    private void Resume()
    {
        this.menu.Hide();
    }

    private void Exit()
    {
        System.Environment.Exit(0);
    }

    private void GameOn()
    {
        ConsoleKeyInfo pressedKey;
        while (true)
        {
            pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (previousSelectedOption == menu.OptionCount() - 1) previousSelectedOption = 0;
                else previousSelectedOption++;

                this.menu.Show(previousSelectedOption);
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (previousSelectedOption == 0) previousSelectedOption = menu.OptionCount() - 1;
                else previousSelectedOption--;

                this.menu.Show(previousSelectedOption);
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                menu.Hide();
                MenuAction(menu.OptionCount() * 10 + previousSelectedOption);
            }
            else if (pressedKey.Key == ConsoleKey.Escape && isGameOn)
            {
                if (menu.OptionCount() == 4)
                {
                    this.menu = new Menu(new string[] { "Resume", "Reset", "Instructions", "High Scores", "Exit" });
                }
                this.menu.Show(previousSelectedOption);
            }
        }
    }

    private void MenuAction(int action)
    {
        switch (action)
        {
            case 40:
            case 51:
                Start();
                break;
            case 50:
                menu.Hide();
                break;
            case 41:
            case 52:
                string instruction = Utils.ReadFromCSV(INSTRUCTIONS);
                Console.WriteLine(instruction);
                EscapeKeyPressed();
                break;
            case 42:
            case 53:
                string scores = Utils.ReadFromCSV(HIGHSCORES);
                Console.WriteLine(scores);
                EscapeKeyPressed();
                break;
            case 43:
            case 54:
                System.Environment.Exit(0);
                break;
        }
    }

    private void EscapeKeyPressed()
    {
        ConsoleKeyInfo pressedKey;

        while (!menu.IsShown)
        {
            pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                menu.Show(previousSelectedOption);
                break;
            }
        }
    }

    private void Play()
    {
        try
        {
            while (player.Credits > 0)
            {
                Direction direction = player.ChooseDirection();

                switch (direction)
                {
                    case Direction.UP:
                        ProcessDirection(player, player.Position.Row - 1, player.Position.Column, player.Position.Depth);
                        break;
                    case Direction.DOWN:
                        ProcessDirection(player, player.Position.Row + 1, player.Position.Column, player.Position.Depth);
                        break;
                    case Direction.LEFT:
                        ProcessDirection(player, player.Position.Row, player.Position.Column - 1, player.Position.Depth);
                        break;
                    case Direction.RIGHT:
                        ProcessDirection(player, player.Position.Row, player.Position.Column + 1, player.Position.Depth);
                        break;
                    case Direction.FORWARD:
                        ProcessDirection(player, player.Position.Row, player.Position.Column, player.Position.Depth - 1);
                        break;
                    case Direction.BACKWARD:
                        ProcessDirection(player, player.Position.Row, player.Position.Column, player.Position.Depth + 1);
                        break;
                    case Direction.ESCAPE: return;
                    default:
                        break;
                }

                if (player.Credits == 0)
                {
                    throw new ArgumentException();
                }

                DisplayCurrentPlayerInfo();
            }
        }
        catch (IndexOutOfRangeException ioore)
        {
            Console.Clear();
            Console.WriteLine("Congrats you escaped!");

            string[] highscores = Utils.ReadFromCSV(HIGHSCORES).Trim().Split('\n');
            List<Score> scores = new List<Score>();
            for (int i = 0; i < highscores.Length; i++)
            {
                string[] highscore = Regex.Split(highscores[i], @"[\W]+");
                scores.Add(new Score(highscore[0], int.Parse(highscore[1])));
            }

            scores.Add(new Score(player.Nickname, player.Credits));
            scores = scores.OrderByDescending(x => x.PlayerScore).ToList<Score>();

            Utils.WriteToCSV(scores);
            Console.WriteLine(Utils.ReadFromCSV(HIGHSCORES));
        }
        catch (ArgumentException ae)
        {
            DisplayCurrentPlayerInfo();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over! You run out of credits!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private void ProcessDirection(Player player, int row, int column, int depth)
    {
        string position = null;
        if (IsDirectionPassable(row, column, depth))
        {
            position = string.Format("{0},{1},{2}", row, column, depth);
            if (player.IsVisited(position))
            {
                player.Position = new Player.Coordinate(row, column, depth);
            }
            else
            {
                if (Utils.DisplayChallenge(challenges))
                {
                    player.MarkVisited(position);
                    player.Position = new Player.Coordinate(row, column, depth);
                }
                player.Credits--;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You hit a Wall! Try again!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private void DisplayCurrentPlayerInfo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("---------------------------------");
        Console.WriteLine(string.Format("current position: {0},{1},{2}", player.Position.Row, player.Position.Column, player.Position.Depth));
        Console.WriteLine(string.Format("credits left: {0}", player.Credits));
        Console.WriteLine("---------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private bool IsDirectionPassable(int row, int column, int depth)
    {
        return labyrinth[row, column, depth] == 1 ? true : false;
    }

    private void PlayWinner()
    {

    }

    private void PlayGameOver()
    {

    }
}
