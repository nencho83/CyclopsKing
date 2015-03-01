using System;
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
    
}
