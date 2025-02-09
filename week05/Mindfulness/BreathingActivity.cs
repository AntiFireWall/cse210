namespace Mindfulness;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity helps you relax by guiding you through a simple breathing exercise. Just clear your mind and lets begin.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Write("\n \n");
        double amount = _duration / 10;
        double timeLeft = _duration - (amount * 10);
        for (int i = 0; i < amount; i++)
        {
            string breathIn = "Breath In";
            string breathOut = "Breath Out";
            foreach (char letter in breathIn)
            {
                Console.Write(letter);
                Thread.Sleep(222);
            }
            ShowDotAnimation(3);
            Console.Write("\n");
            foreach (char letter in breathOut)
            {
                Console.Write(letter);
                Thread.Sleep(200);
            }
            ShowDotAnimation(3);
            Console.Write("\n \n");
        }
        Thread.Sleep((int)timeLeft * 1000);
        DisplayEndingMessage();
    }
}