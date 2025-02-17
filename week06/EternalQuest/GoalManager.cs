using System.Diagnostics;
using System.IO; 

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level = 1;
    private List<string> _masteryLevels = ["Beginner", "Intermediate", "Advanced", "Goal Master"];

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        bool run = true;
        while (run)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Enter selection number: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalNames(); break;
                case "3": SaveGoals();break;
                case "4": LoadGoals();break;
                case "5": RecordEvent(); break;
                case "6": run = false; break;
                default: Console.WriteLine("Invalid input. Try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your score is: {_score}");
        string title = "";
        if (_score >= 100)
        {
            _level = _score / 100 ;
        }
        Console.WriteLine($"Level: {_level}");
        switch (_level)
        {
            case <5: title = _masteryLevels[0]; break;
            case <10: title = _masteryLevels[1]; break;
            case <=19: title = _masteryLevels[2]; break;
            case >=20: title = _masteryLevels[3]; break;
        }
        Console.WriteLine($"Title: {title}");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count != 0)
        {
            int i = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"  {i}. {goal.GetStringRepresentation()}");
                i++;
            }
            
        }
        else
        {
            Console.WriteLine("You haven't set any goals yet!");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select a goal type:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Enter selection number: ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1": Console.Write("Enter goal name: ");
                string goalName = Console.ReadLine();
                Console.Write("Enter goal description: ");
                string goalDescription = Console.ReadLine();
                Console.Write("Enter points amount associated with this goal: ");
                int goalPoints = int.Parse(Console.ReadLine());
                _goals.Add(new SimpleGoal(goalName, goalDescription, goalPoints)); break;
            case "2": Console.Write("Enter goal name: ");
                goalName = Console.ReadLine();
                Console.Write("Enter goal description: ");
                goalDescription = Console.ReadLine();
                Console.Write("Enter points amount associated with this goal: ");
                goalPoints = int.Parse(Console.ReadLine());
                _goals.Add(new EternalGoal(goalName, goalDescription, goalPoints)); break;
            case "3": Console.Write("Enter goal name: ");
                goalName = Console.ReadLine();
                Console.Write("Enter goal description: ");
                goalDescription = Console.ReadLine();
                Console.Write("Enter points amount associated with this goal: ");
                goalPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter how many times you need to complete the goal: ");
                int goalTime = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus potions after complition: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, goalTime, bonusPoints)); break;
            default: Console.WriteLine("Invalid input. Try again."); break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count != 0)
        {
            ListGoalNames();
            Console.Write($"Enter selection number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (_goals[result - 1].IsComplete() == false)
                {
                    _goals[result - 1].RecordEvent();
                    Console.WriteLine($"Good work! You earned {_goals[result - 1].GetPoints()} points."); 
                    _score += _goals[result - 1].GetPoints();
                }
                else
                {
                    Console.WriteLine($"You have already completed this goal.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
        else
        {
            Console.WriteLine("You haven't set any goals yet!");
        }
    }

    public void SaveGoals()
    {
        Console.Write($"Enter player name: ");
        string fileName = "..\\..\\..\\..\\EternalQuest\\" + Console.ReadLine() + ".txt";
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            sw.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                sw.WriteLine(goal.GetDetailsString());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write($"Enter player name: ");
        string fileName = "..\\..\\..\\..\\EternalQuest\\" + Console.ReadLine() + ".txt";
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] goalInfo = line.Split("%");

            switch (goalInfo[0])
            {
                case "sg": _goals.Add(new SimpleGoal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]), goalInfo[4].Contains("True"))); ; break;
                case "eg": _goals.Add(new EternalGoal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]))); break;
                case "cg": _goals.Add(new ChecklistGoal(goalInfo[1], goalInfo[2], int.Parse(goalInfo[3]), int.Parse(goalInfo[4]), int.Parse(goalInfo[5]), int.Parse(goalInfo[6]))); break;
                default: _score = int.Parse(goalInfo[0]); break;
            }
        }
    }
}