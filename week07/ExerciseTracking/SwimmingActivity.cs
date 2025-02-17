namespace ExerciseTracking;

public class SwimmingActivity : Activity
{
    private double _laps;

    public SwimmingActivity(string date, int activityLength, double laps) : base(date, activityLength)
    {
        _laps = laps;
        _activityType = "Swimming";
    }
    
    public override double GetDistance()
    {
        return (_laps * 50) / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _activityLength) * 60;
    }

    public override double GetPace()
    {
        return _activityLength / GetDistance();
    }
    
    public override void GetSummery()
    {
        Console.WriteLine($"{_date} {_activityType} ({_activityLength} min): Laps: {_laps}, Distance {GetDistance().ToString("0.0")} km, Speed: {GetSpeed().ToString("0.0")} kph, Pace: {GetPace().ToString("0.0")} min per km"); 
    }
    
}