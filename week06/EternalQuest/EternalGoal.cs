namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }

    public override string GetStringRepresentation()
    {
        return $"[~] {_shortName} ({_description})";
    }

    public override string GetDetailsString()
    {
        return "eg%" + base.GetDetailsString();
    }
}