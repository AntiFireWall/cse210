namespace ExerciseTracking;

public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, int activityLength, double speed) : base(date, activityLength)
    {
        _speed = speed;
        _activityType = "Cycling";
    }
    
    public override double GetDistance()
    {
        return (_speed / 60) * _activityLength;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return _activityLength / GetDistance();
    }
}