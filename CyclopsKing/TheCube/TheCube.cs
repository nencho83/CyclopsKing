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
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Nenov\Documents\Visual Studio 2013\Projects\TeamWorkProject\Challenge\computer_skills_severity_1.csv");
            // Display the file contents by using a foreach loop.          
            foreach (string line in lines)
            {
                challenges.Add(Utils.takeParts(line));
                // Console.WriteLine(challenges.Count);
            }
        if(myPlayer.CheckForWall(myPlayer.ChooseDirection())>0) Console.WriteLine("Yess");
        Console.WriteLine("We are here");
    }
}