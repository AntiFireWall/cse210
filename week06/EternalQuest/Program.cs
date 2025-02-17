using System;
using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        // I made a level system that give the player a title depending on their leve, which increases after 100 points every time.
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}