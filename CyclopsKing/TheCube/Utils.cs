using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
/// <summary>
/// 
/// </summary>
class Utils
{
    public static int[, ,] GenerateLabyrinth(int cubeSize)
    {
        Random generator = new Random();
        int[, ,] theCube = new int[cubeSize, cubeSize, cubeSize];
        int row = cubeSize / 2, column = row, depth = row;
        theCube[row, column, depth] = 1;
        int passableCellsCount = (int)(Math.Pow(cubeSize, 3) / 10);
        Hashtable passableCells = new Hashtable();
        int count, direction;

        // generate 3D labyrinth
        while (true)
        {
            direction = generator.Next(6);
            switch (direction)
            {
                case 0: // left
                    column--;
                    break;
                case 1: // right
                    column++;
                    break;
                case 2: // forward
                    depth--;
                    break;
                case 3: // backward
                    depth++;
                    break;
                case 4: // up
                    row--;
                    break;
                case 5: // down
                    row++;
                    break;
                default:
                    break;
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
            if (count > 2) continue;

            String position = row + "," + column + "," + depth;
            if (passableCells.ContainsKey(position)) continue;

            passableCells.Add(position, true);

            theCube[row, column, depth] = 1;
        }

        return theCube;
    }
    public static bool displayChallenge(List<Challenge> questions)
        {
            Random r = new Random();
            int rInt = r.Next(0, questions.Count);
            while (questions[rInt].answered == 1)
            {
                r = new Random();
                rInt = r.Next(0, questions.Count);
            }
            Challenge currChallenge = questions[rInt];
            Console.WriteLine(currChallenge.question);
            Console.WriteLine("Please enter the number of the current answer:");
            Console.WriteLine("1." + currChallenge.answers[0]);
            Console.WriteLine("2." + currChallenge.answers[0]);
            Console.WriteLine("3." + currChallenge.answers[0]);
            int i = 30;
            
            while ( !Console.KeyAvailable)
            {
                Console.SetCursorPosition(20, 15);
                Console.Write("  ");
                Console.SetCursorPosition(20, 15);
                Console.Write("Time: {0}", i);
                Thread.Sleep(1000);
                i--;
            }
            System.ConsoleKeyInfo key = Console.ReadKey(true);
            int selection=0;
            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1) selection = 1;
            else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2) selection = 2;
            else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3) selection = 3;

            if (currChallenge.rightAnswer == currChallenge.answers[selection - 1])
            {
                return true;
                questions[rInt].answered = 1;
            }
            else return false;
        }
}
