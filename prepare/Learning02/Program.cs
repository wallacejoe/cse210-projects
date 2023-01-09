using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Ace Industries";
        job1._startYear = 2019;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Landscaper";
        job2._company = "Cutting Edge";
        job2._startYear = 2015;
        job2._endYear = 2018;

        Resume resume1 = new Resume();
        resume1._name = "Joseph Wallace";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.DisplayResume();
    }
}