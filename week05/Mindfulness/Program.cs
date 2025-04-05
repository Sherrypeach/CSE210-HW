using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public int Duration => _duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine(_description + "\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);

        PerformActivity();

        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.\n");
        ShowSpinner(3);

        LogActivity();
    }

    protected abstract void PerformActivity();

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void LogActivity()
    {
        string logEntry = $"{DateTime.Now}: {_name} for {_duration} seconds.";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            Countdown(4);
            elapsed += 4;
            if (elapsed >= _duration) break;

            Console.Write("Breathe out... ");
            Countdown(4);
            elapsed += 4;
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)] + "\n");
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"> {question}");
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)] + "\n");
        Console.WriteLine("You may begin in:");
        Countdown(3);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        int totalTimeSpent = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine($"\nThanks for using the program!");
                    Console.WriteLine($"Total time spent in mindfulness: {totalTimeSpent} seconds.");
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Thread.Sleep(1500);
                    continue;
            }

            activity.Start();
            totalTimeSpent += activity.Duration;
        }
    }
}


