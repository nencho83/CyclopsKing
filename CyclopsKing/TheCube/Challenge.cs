using System;
/// <summary>
/// 
/// </summary>
public class Challenge : IChallenge
{
    private bool isAnswered;
    private int severity;
    private string question;
    private string correctAnswer;
    private string[] answers = new string[3];
    private string category;
    private string rightAnswer;

   // public Challenge(int severity, string question, string correctAnswer, string[] answers)
    public Challenge()
    {
        this.isAnswered = false;
        this.severity = severity;
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.answers = answers;
    }

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

    public bool IsAnswered
    {
        get { return this.isAnswered; }
        set { this.isAnswered = value; }
    }

    public int Severity
    {
        get { return this.severity; }
    }

    public string Question
    {
        get { return this.question; }
    }

    public string CorrectAnswer
    {
        get { return this.correctAnswer; }
    }

    public string[] Answers
    {
        get { return this.answers; }
    }
}
