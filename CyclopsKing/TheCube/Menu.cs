using System;
using System.IO;
/// <summary>
/// 
/// </summary>
sealed class Menu : IMenu
{
    private const string INSTRUCTIONS = @".\..\..\Instructions.txt";
    private const string HIGHSCORES = @".\..\..\Test.csv";

    public void DisplayMenu()
    {
        Console.Clear();
        string[] options = { "Start Game", "Instructions", "High Scores", "Exit" };
        int selectedOption = 0;

        while (true)
        {
            PrintMenu(options, selectedOption);

            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (selectedOption == options.Length - 1) selectedOption = 0;
                else selectedOption++;
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (selectedOption == 0) selectedOption = options.Length - 1;
                else selectedOption--;
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                switch (selectedOption)
                {
                    case 0: //StartGame;
                        return;
                    case 1: //Instructions;
                        string instructions = Utils.ReadFromCSV(INSTRUCTIONS);
                        Console.WriteLine(instructions);
                        EscapeKeyPressed();
                        break;
                    case 2: //Highscores;
                        string scores = Utils.ReadFromCSV(HIGHSCORES);
                        Console.WriteLine(scores);
                        EscapeKeyPressed();
                        break;
                    case 3: //Exit
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }

    private void PrintMenu(string[] options, int selectedOption)
    {
        Console.CursorVisible = false;
        Console.Clear();
        int leftOffSet = (Console.WindowWidth / 2);
        int topOffSet = (Console.WindowHeight / 2);
        Console.SetCursorPosition(0, topOffSet);

        Console.WriteLine(String.Format("{0," + leftOffSet + "}", options[0]));
        Console.WriteLine(String.Format("{0," + leftOffSet + "}", options[1]));
        Console.WriteLine(String.Format("{0," + leftOffSet + "}", options[2]));
        Console.WriteLine(String.Format("{0," + leftOffSet + "}", options[3]));

        Console.SetCursorPosition(0, Console.CursorTop - (options.Length - selectedOption));
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0," + leftOffSet + "}", options[selectedOption]);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private static void EscapeKeyPressed()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        while (Console.ReadKey().Key != ConsoleKey.Escape)
        {
            Console.CursorLeft = 0;
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

