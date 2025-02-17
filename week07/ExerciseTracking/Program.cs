using System;
using ExerciseTracking;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = [new RunningActivity("17 Feb 2025", 30, 5.3),
                                     new CyclingActivity("17 Feb 2025", 20, 13.2),
                                     new SwimmingActivity("17 Feb 2025", 40, 50)];

        foreach (Activity activity in activities)
        {
            activity.GetSummery();
        }
    }
}