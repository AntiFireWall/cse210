using System.Runtime.InteropServices;

namespace Mindfulness;

public class ListingActivity :Activity
{
    private int _count;
    private List<string> _prompts = ["Who are people that you appreciate?", 
                                     "What are personal strengths of yours?",
                                     "When have you felt the Holy Ghost this month?",
                                     "Who are some of your personal heroes?",
                                     "Who are people that you have helped this week?"];
    
    const int _StdInputHandle = -10;

    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CancelIoEx(IntPtr handle, IntPtr lpOverlapped);

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "The purpose of this activity is to reflect on things that happened in your life by having you list as many things as you can in a certain area.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        bool read = true;
        Console.Write("\n");
        Console.WriteLine("List as many responses as you can to this prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in:  ");
        ShowCountDownAnimation(5);
        Console.Write("\n");
        Task.Delay(_duration * 1000).ContinueWith(_ =>
        {
            //Console.WriteLine("Yes I am being sassy");
            if (read)
            {
                // Timeout => cancel the console read
                var handle = GetStdHandle(_StdInputHandle);
                CancelIoEx(handle, IntPtr.Zero);
            }
        });
        try
        {
            bool test = false;
            while (!test)
            {
                Console.Write("> ");
                read = true;
                Console.ReadLine();
                read = false;
                _count++;
            }
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine($"\nYou listed {_count} things.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"\nYou listed {_count} things.");
        }
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(0, _prompts.Count - 1)];
    }
}