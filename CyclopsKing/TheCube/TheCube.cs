using System;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
class TheCube
{
    public static int[, ,] theCubeLabyrinth = Utils.GenerateLabyrinth(9);
    public static Player myPlayer;
    public static List<Challenge> challenges = new List<Challenge>();

    public static void Main(String[] args)
    {
        Menu.CallMenu();
        // Read each line of the file into a string array. Each element of the array is one line of the file. 
        string[] lines = System.IO.File.ReadAllLines(@"..\..\computer_skills_severity_1.csv");

        // Display the file contents by using a foreach loop.          
        foreach (string line in lines)
        {
            challenges.Add(Utils.takeParts(line));
            // Console.WriteLine(challenges.Count);
        }
        bool answered = false;
        do
        {
            foreach (string key in myPlayer.passedMoves.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, myPlayer.passedMoves[key]));
            } int curDirection = myPlayer.ChooseDirection();
            if (!myPlayer.CheckForWall(curDirection))
            {
                if (curDirection > 0) answered = true;
                myPlayer.ChangeCoordinates(curDirection, answered);
            }

        }
        while (myPlayer.IsInCubeBoundary(myPlayer.coordinates.X, myPlayer.coordinates.Y, myPlayer.coordinates.Z) && myPlayer.Credits>0);
        if (myPlayer.Credits == 0) Console.WriteLine("You are dead");
        else Console.WriteLine("You are out");
        Console.WriteLine("We are here");

    }
}