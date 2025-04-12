using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    public Goal(string name)
    {
        Name = name;
        Points = 0;
    }

    public abstract void RecordEvent();

    public virtual string GetDetails()
    {
        return $"{Name}: {Points} points";
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name) { }

    public override void RecordEvent()
    {
        // SimpleGoal gets 1000 points when completed
        Points += 1000;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name) { }

    public override void RecordEvent()
    {
        // Eternal goals give 100 points each time they are recorded
        Points += 100;
    }
}

class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int Progress { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int target, int bonus) : base(name)
    {
        Target = target;
        Progress = 0;
        Bonus = bonus;
    }

    public override void RecordEvent()
    {
        // Each time recorded, gain points
        Progress++;
        Points += 50;  // Each record gains 50 points

        if (Progress >= Target)
        {
            // Bonus when completing the target
            Points += Bonus;
        }
    }

    public override string GetDetails()
    {
        return $"{Name}: {Progress}/{Target} completed, {Points} points";
    }
}

class GoalManager
{
    public List<Goal> Goals { get; set; }

    public GoalManager()
    {
        Goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < Goals.Count)
        {
            Goals[index].RecordEvent();
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.GetDetails());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // Create different types of goals
        Goal simpleGoal = new SimpleGoal("Run a Marathon");
        Goal eternalGoal = new EternalGoal("Read Scriptures");
        Goal checklistGoal = new ChecklistGoal("Attend the Temple", 10, 500);

        // Add goals to the manager
        goalManager.AddGoal(simpleGoal);
        goalManager.AddGoal(eternalGoal);
        goalManager.AddGoal(checklistGoal);

        // Simulate events being recorded
        goalManager.RecordEvent(0); // Run marathon
        goalManager.RecordEvent(1); // Read scriptures
        goalManager.RecordEvent(2); // Attend the temple (first time)

        // Display current status of all goals
        goalManager.DisplayGoals();

        // Optionally, save goals to a file
        SaveGoals(goalManager.Goals);

        // Optionally, load goals from a file
        // goalManager.Goals = LoadGoals();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void SaveGoals(List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                // Save the goal's name and points
                writer.WriteLine(goal.Name + "," + goal.Points);
            }
        }
    }

    static List<Goal> LoadGoals()
    {
        List<Goal> loadedGoals = new List<Goal>();

        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                // Example logic to load goals (you could adjust this as needed)
                loadedGoals.Add(new SimpleGoal(parts[0]) { Points = int.Parse(parts[1]) });
            }
        }

        return loadedGoals;
    }
}
