using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.Write("Enter countdown time per round (seconds): ");
        int countdownTime = int.Parse(Console.ReadLine());
        
        while (!scripture.AllWordsHidden())
        {
            ClearScreen();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words, type 'quit' to exit.");
            
            bool timedOut = false;
            Thread timerThread = new Thread(() =>
            {
                for (int i = countdownTime; i > 0; i--)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write($"Time left: {i} seconds ");
                    Thread.Sleep(1000);
                }
                timedOut = true;
            });
            
            timerThread.Start();
            string input = Console.ReadLine();
            timerThread.Interrupt();
            
            if (input.ToLower() == "quit")
                break;
            
            if (timedOut || string.IsNullOrEmpty(input))
                scripture.HideRandomWords();
        }
        
        ClearScreen();
        scripture.Display();
        Console.WriteLine("\nGreat job! You've completed the scripture memorization.");
    }
    
    static void ClearScreen()
    {
        Console.Clear();
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;
    
    public Scripture(string refText, string text)
    {
        reference = new Reference(refText);
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }
    
    public void Display()
    {
        Console.WriteLine($"{reference.GetText()}\n");
        Console.WriteLine(string.Join(" ", words.Select(w => w.GetDisplayText())));
    }
    
    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = 3;
        
        for (int i = 0; i < wordsToHide; i++)
        {
            var visibleWords = words.Where(w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0) break;
            visibleWords[rand.Next(visibleWords.Count)].Hide();
        }
    }
    
    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden());
    }
}

class Reference
{
    private string text;
    
    public Reference(string refText)
    {
        text = refText;
    }
    
    public string GetText()
    {
        return text;
    }
}

class Word
{
    private string text;
    private bool hidden;
    
    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }
    
    public void Hide()
    {
        hidden = true;
    }
    
    public bool IsHidden()
    {
        return hidden;
    }
    
    public string GetDisplayText()
    {
        return hidden ? new string('_', text.Length) : text;
    }
}