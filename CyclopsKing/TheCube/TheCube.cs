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
                int curDirection = myPlayer.CheckForWall(myPlayer.ChooseDirection());
                if(curDirection>0)answered = Utils.displayChallenge(challenges);
                myPlayer.ChangeCoordinates(curDirection, answered);
            }
            while (myPlayer.IsInCubeBoundary(myPlayer.coordinates.X, myPlayer.coordinates.Y, myPlayer.coordinates.Z));
    Console.WriteLine("We are here");

    }
}