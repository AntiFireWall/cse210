namespace EternalQuest;

public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public virtual int GetPoints()
    {
        return _points;
    }

    public virtual void RecordEvent()
    {
        
    }

    public virtual bool IsComplete()
    {
        return false;
    }
    
    public virtual string GetStringRepresentation()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})";
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName}%{_description}%{_points}%{IsComplete()}";
    }
}