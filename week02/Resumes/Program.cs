using System;
using Resumes;

class Program
{
    static void Main(string[] args)
    {
       Job job1 = new Job();
       job1._company = "Fun Inc.";
       job1._jobTitle = "Clown";
       job1._startYear = 2018;
       job1._endYear = 2020;
       Job job2 = new Job();
       job2._company = "Night Inc.";
       job2._jobTitle = "Assasin";
       job2._startYear = 2020;
       job2._endYear = 2023;
       
       Resume resume1 = new Resume();
       resume1._name = "Seth Morgen";
       resume1._jobs.Add(job1);
       resume1._jobs.Add(job2);
       
       resume1.DisplayResumeInfo();

    }
}