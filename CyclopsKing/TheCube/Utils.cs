using System;
using System.Text;
using System.Collections;
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
}
