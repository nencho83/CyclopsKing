﻿using System;
using System.IO;
/// <summary>
/// 
/// </summary>
class Menu : IMenu
{

    static void PrintMenu(int selection, string[] Options)
    {

        Console.CursorVisible = false;
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
        while (true)
        {

            ConsoleKeyInfo pressedKey = Console.ReadKey();
            bool irregularKeyPressed = pressedKey.Key != ConsoleKey.DownArrow ||
                                       pressedKey.Key != ConsoleKey.UpArrow ||
                                       pressedKey.Key != ConsoleKey.Escape ||
                                       pressedKey.Key != ConsoleKey.Enter;
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
                    return;
                } //StartGame;
                else if (selection == 1)return; //Instructions;
                else if (selection == 1) //Instructions;
                {
                    string instructions = "The game represents labyrinth in 3D Cube. The Player is placed in the middle of the Cube and his task is to find a way out. In the beginning of the game he chooses category of questions:\n - IT quiz \n -	Movie quiz \n -	Science quiz \nQuestions in each category are separated in three severities. The Player has 30 seconds to answer the question. If he answers before the time has elapsed the remaining time is added to the time of his next question. \nPlayer moves through the playfield and gives a direction by pressing the arrow keys. When he enters a room he has to answer a question from the chosen category in order to move in the next room. When he gives wrong answer his credits decreased he stays in the same room and new question is given. If the Player runs out of credits the game is over his score is recorded if it is among the Top 10 scores.\nIf the Player gives the correct answer he chooses his next direction. The closer he gets to the wall of the room, which is the exit of The Cube, the harder the question gets. When he successfully answers the last question he sees his current score and the rank list.";
                }

                else if (selection == 2) //Highscore;
                {
                     string scores=Utils.ReadFromCSV(@"..\..\Test.csv");
                     Console.Clear();
                     Console.WriteLine(scores);
                     Console.ReadKey();
                }

               else if (selection == 3)//Exit
                {
                    System.Environment.Exit(0);
                }
            }
           
            if (irregularKeyPressed == true)
            {
                PrintMenu(selection, Options);
            }
        }
    }
}

