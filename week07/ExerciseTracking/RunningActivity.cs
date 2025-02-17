namespace ExerciseTracking;

public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(string date, int activityLength, double distance) : base(date, activityLength)
    {
        _distance = distance;
        _activityType = "Running";
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / _activityLength) * 60;
    }

    public override double GetPace()
    {
        return _activityLength / _distance;
    }
}