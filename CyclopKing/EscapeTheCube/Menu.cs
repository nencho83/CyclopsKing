using System;
using System.Text;

public class Menu
{
    private bool isShown;
    private string[] options;
    private StringBuilder menu = new StringBuilder();

    public Menu(string[] options)
    {
        this.isShown = false;
        this.options = options;
    }

    public bool IsShown
    {
        get { return this.isShown; }
        set { this.isShown = value; }
    }

    public void Show(int selectedOption)
    {
        this.isShown = true;
        Console.CursorVisible = false;
        Console.Clear();
        int leftOffSet = (Console.WindowWidth / 2) + 3;
        int topOffSet = (Console.WindowHeight / 2) - 2;
        Console.SetCursorPosition(0, topOffSet);

        foreach (var option in options)
        {
            Console.WriteLine(String.Format("{0," + leftOffSet + "}", option));
        }

        Console.SetCursorPosition(0, Console.CursorTop - (options.Length - selectedOption));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0," + leftOffSet + "}", options[selectedOption]);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public void Hide()
    {
        this.isShown = false;
        Console.Clear();
    }

    public int OptionCount()
    {
        return this.options.Length;
    }
}
