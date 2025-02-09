namespace Mindfulness;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "Activity Description";
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        bool vaildInput = false;
        while (!vaildInput)
        {
            Console.Write($"How long do you want this activity to last?(Enter in seconds): ");
            vaildInput = int.TryParse(Console.ReadLine(), out _duration);
            if (!vaildInput)
            {
                Console.WriteLine("Please enter a valid duration.");
            }
        }
        Console.Clear();
        Console.Write($"Get ready");
        ShowDotAnimation(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nCongratulations on finishing the activity.");
        ShowSpinerAnimation(3);
        Console.WriteLine($"\nThe activity lasted {_duration} seconds.");
        ShowSpinerAnimation(5);
    }

    public void ShowDotAnimation(int sec)
    {
        for (int i = 0; i < sec; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }

    public void ShowSpinerAnimation(int sec)
    {
        List<char> spiners = ['|', '/', '-', '\\'];
        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(sec);
        while (DateTime.Now < end)
        {
            Console.Write($"\b{spiners[count]}");
            Thread.Sleep(500);
            if (count == 3)
            {
                count = 0;
            }
            else
            {
                count++;
            }
            
        }
        Console.Write("\b ");
    }

    public void ShowCountDownAnimation(int sec)
    {
        for (int i = 1; i <= sec; i++)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
    }
}