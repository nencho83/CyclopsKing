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

    public Challenge(int severity, string question, string correctAnswer, string[] answers)
    {
        this.isAnswered = false;
        this.severity = severity;
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.answers = answers;
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
