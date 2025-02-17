namespace ExerciseTracking;

public abstract class Activity
{
    protected string _date;
    protected int _activityLength;
    protected string _activityType;

    public Activity(string date, int activityLength)
    {
        _date = date;
        _activityLength = activityLength;
        _activityType = "Activity";
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual void GetSummery()
    {
        Console.WriteLine($"{_date} {_activityType} ({_activityLength} min): Distance {GetDistance().ToString("0.0")} km, Speed: {GetSpeed().ToString("0.0")} kph, Pace: {GetPace().ToString("0.0")} min per km");
    }
}