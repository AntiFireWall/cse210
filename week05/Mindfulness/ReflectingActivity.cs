namespace Mindfulness;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = ["Think of a time when you stood up for someone else.",
                                     "Think of a time when you did something really difficult.",
                                     "Think of a time when you helped someone in need.",
                                     "Think of a time when you did something truly selfless."];
    private List<string> _questions = ["Why was this experience meaningful to you?",
                                       "Have you ever done anything like this before?",
                                       "How did you get started?",
                                       "How did you feel when it was complete?",
                                       "What made this time different than other times when you were not as successful?",
                                       "What is your favorite thing about this experience?",
                                       "What could you learn from this experience that applies to other situations?",
                                       "What did you learn about yourself through this experience?",
                                       "How can you keep this experience in mind in the future?"];
    
    

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "With this activity you will be able to reflect on important times in your life, which will help you gain confidence in yourself.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Write("\n \n");
        double amount = _duration / 5;
        double timeLeft = _duration - (amount * 5);
        Console.WriteLine("Consider this prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.WriteLine("When you think of somthing, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on the following questions related to this experience.");
        Console.Write($"You may begin in:  ");
        ShowCountDownAnimation(5);
        Console.Clear();
        List<string> unsedQuestions = _questions;
        for (int i = 0; i < amount; i++)
        {
            int question = GetRandomQuestionIndex(unsedQuestions);
            Console.Write($"\n> {unsedQuestions[question]}  ");
            ShowSpinerAnimation(5);
            unsedQuestions.RemoveAt(question);
        }
        Thread.Sleep((int)timeLeft * 1000);
        DisplayEndingMessage();
    }
    
    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(0, _prompts.Count - 1)];
    }
    
    private int GetRandomQuestionIndex(List<string> questions)
    {
        Random rnd = new Random();
        return rnd.Next(0, questions.Count - 1);
    }
}