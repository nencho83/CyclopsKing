using System;
/// <summary>
/// 
/// </summary>
class TheCube
{
    public static int[, ,] theCubeLabyrinth = Utils.GenerateLabyrinth(9);
    public static Player myPlayer;
    public static void Main(String[] args)
    {
        Menu.CallMenu();
    }
}