using System;
using System.Collections.Generic;

// Job class stores details of a job
class Job
{
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    public Job(string company, string jobTitle, int startYear, int endYear)
    {
        Company = company;
        JobTitle = jobTitle;
        StartYear = startYear;
        EndYear = endYear;
    }

    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}

// Resume class stores a person's name and a list of jobs
class Resume
{
    public string Name { get; set; }
    private List<Job> Jobs { get; set; }

    public Resume(string name)
    {
        Name = name;
        Jobs = new List<Job>();
    }

    public void AddJob(Job job)
    {
        Jobs.Add(job);
    }

    public void Display()
    {
        Console.WriteLine($"Resume for: {Name}\n");
        foreach (var job in Jobs)
        {
            job.Display();
        }
    }
}

// Main program to test the classes
class Program
{
    static void Main()
    {
        Resume myResume = new Resume("John Doe");
        myResume.AddJob(new Job("Microsoft", "Software Engineer", 2019, 2022));
        myResume.AddJob(new Job("Apple", "Product Designer", 2022, 2024));
        
        myResume.Display();
    }
}
