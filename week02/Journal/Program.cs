using System;
using System.Collections.Generic;

// Entry class represents a single journal entry
class Entry
{
    public string Date { get; set; }
    public string Text { get; set; }
    
    public Entry(string text)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Text = text;
    }
    
    public void Display()
    {
        Console.WriteLine($"[{Date}] {Text}");
    }
}

// Journal class manages a collection of entries
class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string text)
    {
        entries.Add(new Entry(text));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        while (true)
        {
            Console.WriteLine("Choose an option: (1) Add Entry (2) View Entries (3) Exit");
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.Write("Enter your journal entry: ");
                string entryText = Console.ReadLine();
                myJournal.AddEntry(entryText);
            }
            else if (choice == "2")
            {
                myJournal.DisplayEntries();
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}
