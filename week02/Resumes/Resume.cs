namespace Resumes;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void DisplayResumeInfo()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs: ");
        foreach (Job _job in _jobs)
        {
            Console.WriteLine($"{_job._jobTitle} ({_job._company}) {_job._startYear}-{_job._endYear})");
        }
    }
}