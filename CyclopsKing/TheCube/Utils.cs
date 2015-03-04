using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
/// <summary>
/// 
/// </summary>
class Utils
{
    public static int[, ,] Generate3DLabyrinth(int cubeSize)
    {
        int[, ,] theCube = new int[cubeSize, cubeSize, cubeSize];
        int row = cubeSize / 2, column = row, depth = row;
        theCube[row, column, depth] = 1;
        int passableCellsCount = (int)(Math.Pow(cubeSize, 3) / 10);
        Hashtable passableCells = new Hashtable();
        int count, direction;

        Random generator = new Random();
        while (true)
        {
            direction = generator.Next(6);
            switch (direction)
            {
                case 0: column--; break; // left
                case 1: column++; break; // right
                case 2: depth--; break; // forward
                case 3: depth++; break; // backward
                case 4: row--; break; // up
                case 5: row++; break; // down

                default: break;
            }

            if (passableCells.Count < passableCellsCount &&
                (row < 1 || row > cubeSize - 2 || column < 1 || column > cubeSize - 2 || depth < 1 || depth > cubeSize - 2))
            {
                row = column = depth = cubeSize / 2;
                continue;
            }
            else if (!(passableCells.Count < passableCellsCount) &&
                (row < 0 || row > cubeSize - 1 || column < 0 || column > cubeSize - 1 || depth < 0 || depth > cubeSize - 1))
            {
                break;
            }

            count = 0;
            if (row + 1 < cubeSize && theCube[row + 1, column, depth] == 1) count++;
            if (row - 1 >= 0 && theCube[row - 1, column, depth] == 1) count++;
            if (column + 1 < cubeSize && theCube[row, column + 1, depth] == 1) count++;
            if (column - 1 >= 0 && theCube[row, column - 1, depth] == 1) count++;
            if (depth + 1 < cubeSize && theCube[row, column, depth + 1] == 1) count++;
            if (depth - 1 >= 0 && theCube[row, column, depth - 1] == 1) count++;
            if (count > 3) continue;

            String position = row + "," + column + "," + depth;
            if (passableCells.ContainsKey(position)) continue;

            passableCells.Add(position, true);

            theCube[row, column, depth] = 1;
        }

        return theCube;
    }
    public static string ReadFromCSV(string path)
    {
        return File.ReadAllText(@path);
    }
    /*
    public static List<string> ReadFromCSV(string path)
    {
        var lines = new List<string>();
        using (var reader = new StreamReader(@path))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                lines.Add(line);

                line = reader.ReadLine();
            }
        }
        return lines;
    }
    */
    public static bool DisplayChallenge(List<Challenge> questions)
    {
        Random r = new Random();
        int rInt = r.Next(0, questions.Count);
        while (questions[rInt].IsAnswered == true)
        {
            r = new Random();
            rInt = r.Next(0, questions.Count);
        }
        Challenge currChallenge = questions[rInt];
        Console.WriteLine(currChallenge.Question);
        Console.WriteLine("Please enter the number of the current answer:");
        Console.WriteLine("1." + currChallenge.Answers[0]);
        Console.WriteLine("2." + currChallenge.Answers[0]);
        Console.WriteLine("3." + currChallenge.Answers[0]);
        int i = 30;

        //while ( !Console.KeyAvailable)
        //{
        //    Console.SetCursorPosition(30, 35);
        //    Console.Write("  ");
        //    Console.SetCursorPosition(30, 35);
        //    Console.Write("Time: {0}", i);
        //    Thread.Sleep(1000);
        //    i--;
        //}
        System.ConsoleKeyInfo key = Console.ReadKey(true);
        int selection = 0;
        if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1) selection = 1;
        else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2) selection = 2;
        else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3) selection = 3;

        if (currChallenge.CorrectAnswer == currChallenge.Answers[selection - 1])
        {
            return true;
            questions[rInt].IsAnswered = true;
        }
        else return false;
    }
    public static void WriteToCSV(List<string> lines)
    {
        StreamWriter stream = new StreamWriter(@".\..\..\Scores.csv");
        stream.Flush();
        stream.Close();
        for (int i = 0; i < lines.Count; i++)
        {
            File.AppendAllText(@".\..\..\Scores.csv", lines[i] + Environment.NewLine);
        }
    }
    public static void SaveLabyrinthStructure(int[, ,] labyrinth)
    {
        StringBuilder labyrinthToSave = new StringBuilder();

        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            labyrinthToSave.AppendLine("row = " + row);
            for (int depth = 0; depth < labyrinth.GetLength(0); depth++)
            {
                for (int column = 0; column < labyrinth.GetLength(0); column++)
                {
                    labyrinthToSave.Append(labyrinth[row, column, depth] + " ");
                }
                labyrinthToSave.AppendLine();
            }
            labyrinthToSave.AppendLine();
        }

        using (StreamWriter writer = new StreamWriter(@".\..\..\labyrinth.txt"))
        {
            writer.Write(labyrinthToSave);
        }
    }

   
       
     
    public static void Credits(int credits)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Credits left: {0}", credits);
        Console.ResetColor();
    }
    public static Challenge ExtractChallenge(string[] line)
    {
        int severity = int.Parse(line[0]);
        string question = line[1];
        string correctAnswer = line[2];
        string rightAnswer = line[2];
        string[] answers = new string[3];
        Array.Copy(line, 3, answers, 0, 3);

        //  return new Challenge(severity, question, correctAnswer, answers);
        return new Challenge();
    }

    public static void ShowScoreboardOnVictory()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Congratulations you escaped!");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(Utils.ReadFromCSV(@".\..\..\Score.csv"));
    }
  
    public static void ShowScoresOnGameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("GAME OVER");
        Console.ResetColor();
        Console.WriteLine();
    }
    public static void AddPlayerResultToFile(string nickname, int credits)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(nickname).Append(", ").Append(credits);
        string playerResult = Convert.ToString(builder);
        File.AppendAllText(@".\..\..\Score.csv", playerResult + Environment.NewLine);
    }
    public static void WriteToCSV(List<string> lines, string path)
    {
        using (StreamWriter writer = new StreamWriter(@path))
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (i < lines.Count - 1)
                {
                    writer.WriteLine(lines[i]);
                }
                else
                {
                    writer.Write(lines[i]);
                }
            }
        }
    }

    public static Category ChooseCategory()
    {
        Category category = Category.IT;

        int choice = 1;
        do
        {
            if (choice < 1 || choice > 3)
            {
                Console.WriteLine("\nNo Category under this number");
            }

            Console.WriteLine("Choose category and the number");
            Console.WriteLine("1 -> IT quiz");
            Console.WriteLine("2 -> Movie quiz");
            Console.WriteLine("3 -> Science quiz");
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
        }
        while (choice < 1 || choice > 3);

        switch (choice)
        {
            case 1: category = Category.IT; break;
            case 2: category = Category.Movie; break;
            case 3: category = Category.Science; break;
        }
        Console.Clear();

        return category;
    }


}

