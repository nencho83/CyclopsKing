using System;
/// <summary>
/// 
/// </summary>
class Menu : IMenu
{
    static void PrintMenu(int selection, string[] Options)
    {
        Console.Clear();
        int leftOffSet = (Console.WindowWidth / 2);
        int topOffSet = (Console.WindowHeight / 2);
        Console.SetCursorPosition(leftOffSet - Options[0].Length, topOffSet);
        switch (selection)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Options[0]);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[1]));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[2]));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[3])); break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(Options[0]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[1]));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[2]));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[3])); break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(Options[0]);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[1]));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[2]));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[3])); break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(Options[0]);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[1]));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[2]));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", Options[3])); break;
            default:
                break;
        }
    }
    public static void CallMenu()
    {
        Console.Clear();
        string[] Options = { "Start Game", "Instructions", "High Scores", "Exit" };
        int selection = 0;
        PrintMenu(selection, Options);
        string nameOfPlayer = string.Empty;
        while (true)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.DownArrow || pressedKey.Key == ConsoleKey.UpArrow)
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (selection == 3) selection = 0;
                    else selection++;
                    PrintMenu(selection, Options);
                }
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (selection == 0) selection = 3;
                else selection--;
                Console.SetCursorPosition(15, 15);
                Console.Clear();
                PrintMenu(selection, Options);
            }
            if (pressedKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return;
            }
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                if (selection == 0)
                {
                    Console.Clear();
                    TheCube.myPlayer = new Player();
                }
                else if (selection == 1) return;//Instructions;
                else if (selection == 2) return;//Highscore;
                else if (selection == 3) return;//Exit
            }
        }
    }
}

