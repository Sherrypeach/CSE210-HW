using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Journal journal = new Journal();
    static void Main()
    {
        while (true)
        {
            ClearScreen();
            Console.WriteLine("✨ Welcome to Your Cute Journal ✨");
            Console.WriteLine("💖 1. Write a new entry");
            Console.WriteLine("📖 2. Display journal");
            Console.WriteLine("💾 3. Save journal to file");
            Console.WriteLine("📂 4. Load journal from file");
            Console.WriteLine("🚪 5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    Console.WriteLine("Goodbye! Have a lovely day! 🌸");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again! ❌");
                    break;
            }
        }
    }

    static void ClearScreen()
    {
        Console.Clear();
        Console.WriteLine("🌟✨🌸 Welcome to Your Journal 🌸✨🌟\n");
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see kindness in my life today?",
        "What made me smile today? 😊",
        "What is one thing I am grateful for today?"
    };

    public void AddEntry()
    {
        ClearScreen();
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine($"📝 {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        entries.Add(new Entry(date, prompt, response));
        Console.WriteLine("✨ Entry saved! Press any key to continue.");
        Console.ReadKey();
    }

    public void DisplayEntries()
    {
        ClearScreen();
        if (entries.Count == 0)
        {
            Console.WriteLine("📭 No journal entries yet!");
        }
        else
        {
            Console.WriteLine("📜 Your Journal Entries:");
            foreach (var entry in entries)
            {
                Console.WriteLine($"\n📅 {entry.Date}\n💬 {entry.Prompt}\n✍ {entry.Response}\n-----------------------------");
            }
        }
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    public void SaveToFile()
    {
        ClearScreen();
        Console.Write("Enter filename to save (e.g., journal.txt): ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("💾 Journal saved successfully!");
        Console.ReadKey();
    }

    public void LoadFromFile()
    {
        ClearScreen();
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
            Console.WriteLine("📂 Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("❌ File not found!");
        }
        Console.ReadKey();
    }

    private void ClearScreen()
    {
        Console.Clear();
        Console.WriteLine("🌸 Your Cute Journal 🌸\n");
    }
}

class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

