using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
class Challenge : IChallenge
{

    public int answered;
    public int severity;
    public string category;
    public string question;
    public string[] answers = new string[3];
    public string rightAnswer;

    /*TheCube.cs and Challenge.cs both have main() and solution cannot be build
    static void Main()
    {
        List<Challenge> challenges = new List<Challenge>();
        // Read each line of the file into a string array. Each element of the array is one line of the file. 
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Miglena\Documents\Visual Studio 2013\Projects\CSharp2TeamWork\QuizQuestionsLoading\computer_skills_severity_1.csv");
        // Display the file contents by using a foreach loop.          
        foreach (string line in lines)
        {
            challenges.Add(takeParts(line));
            // Console.WriteLine(challenges.Count);
        }
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
*/

    public static Challenge takeParts(string text)
    {
        char[] delimiterChars = { ';' };
        string[] words = text.Split(delimiterChars);
        Challenge challengeTask = new Challenge();
        challengeTask.category = words[0];
        challengeTask.severity = int.Parse(words[1]);
        challengeTask.question = words[2];
        Console.WriteLine("Answer the question: {0}", challengeTask.question);
        Console.WriteLine("Choose the correct answer:");
        for (int i = 0; i < 3; i++)
        {
            challengeTask.answers[i] = words[i + 3];
            int choice = i + 1;
            Console.WriteLine(i + 1 + "->", challengeTask.answers[i]);
        }
        challengeTask.rightAnswer = words[6];
        verifyTheAnswer(challengeTask);

        return challengeTask;
    }


    public static void verifyTheAnswer(Challenge challengeTask)
    {
        Console.WriteLine("Your answer is: ");
        int playersChoice = int.Parse(Console.ReadLine());
        try
        {
            if (challengeTask.answers[playersChoice - 1] == challengeTask.rightAnswer)
            {
                Console.WriteLine("Right answer!!!");
            }
            else
            {
                Console.WriteLine("Wrong answer!!!");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Not available choice!Wrong answer!!!");
        }
    }

}
