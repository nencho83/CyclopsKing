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
        StringBuilder positions = new StringBuilder();
        Hashtable passableCells = new Hashtable();

        // generate 3D labyrinth
        while (passableCells.Count < passableCellsCount)
        {
            switch (generator.Next(6))
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

            // stop if the position goes out of the cube's borders
            if ((row < 0 || row > cubeSize - 1 || column < 0 || column > cubeSize - 1 || depth < 0 || depth > cubeSize - 1))
            {
                row = column = depth = cubeSize / 2;
            }

            String position = row + "," + column + "," + depth;
            if (passableCells.ContainsKey(position)) continue;

            passableCells.Add(position, true);
            positions.Append(position + "\n");

            // set a passable cell
            theCube[row, column, depth] = 1;
        }

        return theCube;
    }
}
