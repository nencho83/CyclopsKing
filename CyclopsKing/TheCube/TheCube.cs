using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
/// <summary>
/// 
/// </summary>
class TheCube
{
    private static int[, ,] labyrinth;
    private static List<Challenge> challenges = new List<Challenge>();

    private static Random generator = new Random();

    public static void Main(String[] args)
    {
        int cubeSize = 2;
        labyrinth = Utils.Generate3DLabyrinth(cubeSize);

        Utils.SaveLabyrinthStructure(labyrinth);

        Menu menu = new Menu();
        menu.DisplayMenu();

        Player player = CreatePlayer(cubeSize / 2);

        string line;
        using (StreamReader reader = new StreamReader(@".\..\..\" + player.Category + "_Questions.csv"))
        {
            while ((line = reader.ReadLine()) != null)
            {
                Challenge challenge = Utils.ExtractChallenge(line.Split('|'));
                challenges.Add(challenge);
            }
        }

        GameOn(player);

    }

    private static Player CreatePlayer(int middle)
    {
        Console.WriteLine("Enter a nickname:");
        string nickname = Console.ReadLine();

        return new Player(nickname, 10, Utils.ChooseCategory(), 0, new Player.Coordinate(middle, middle, middle));
    }

    private static void GameOn(Player player)
    {
        try
        {
            while (player.Credits > 0)
            {
                Direction direction = player.ChooseDirection();
                string previousPosition = string.Format("{0},{1},{2}", player.Position.Row, player.Position.Column, player.Position.Depth);
                string newPosition = null;

                switch (direction)
                {
                    case Direction.UP:
                        newPosition = ProcessDirection(player, player.Position.Row - 1, player.Position.Column, player.Position.Depth);
                        break;
                    case Direction.DOWN:
                        newPosition = ProcessDirection(player, player.Position.Row + 1, player.Position.Column, player.Position.Depth);
                        break;
                    case Direction.LEFT:
                        newPosition = ProcessDirection(player, player.Position.Row, player.Position.Column - 1, player.Position.Depth);
                        break;
                    case Direction.RIGHT:
                        newPosition = ProcessDirection(player, player.Position.Row, player.Position.Column + 1, player.Position.Depth);
                        break;
                    case Direction.FORWARD:
                        newPosition = ProcessDirection(player, player.Position.Row, player.Position.Column, player.Position.Depth - 1);
                        break;
                    case Direction.BACKWARD:
                        newPosition = ProcessDirection(player, player.Position.Row, player.Position.Column, player.Position.Depth + 1);
                        break;
                }

                if (newPosition != null)
                {
                    previousPosition = newPosition;
                    Console.WriteLine(newPosition);
                }
                else
                {
                    Console.WriteLine(previousPosition);
                }
                Utils.Credits(player.Credits);
                if (player.Credits == 0)
                {
                    Utils.ShowScoresOnGameOver();
                }
            }
        }

        catch (IndexOutOfRangeException)
        {
            Utils.AddPlayerResultToFile(player.Nickname, player.Credits);
            Console.Clear();
            Utils.ShowScoreboardOnVictory();
        }
    }

    private static string ProcessDirection(Player player, int row, int column, int depth)
    {
        string position = null;
        if (IsDirectionPassable(row, column, depth))
        {
            if (Utils.DisplayChallenge(challenges))
            {
                position = string.Format("{0},{1},{2}", row, column, depth);
                if (!player.IsVisited(position))
                {
                    player.MarkVisited(position);
                    player.Credits--;
                }
                player.Position = new Player.Coordinate(row, column, depth);
            }
        }
        else
        {
            player.Credits--;
            Console.WriteLine("You hit a Wall! Try again!");
        }
        return position;
    }

    private static bool IsDirectionPassable(int row, int column, int depth)
    {
        return labyrinth[row, column, depth] == 1 ? true : false;
    }
}