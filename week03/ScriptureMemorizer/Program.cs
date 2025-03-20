using System;
using System.Collections.Generic;

// Reference class to store book, chapter, and verse
class Reference
{
    private string book;
    private int chapter;
    private int verse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public string GetDisplayText()
    {
        return $"{book} {chapter}:{verse}";
    }
}

// Word class to manage individual words and their visibility
class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public string GetDisplayText()
    {
        return isHidden ? "_____" : text;
    }
}

// Scripture class to store and manipulate scripture text
class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string book, int chapter, int verse, string text)
    {
        reference = new Reference(book, chapter, verse);
        words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", words.ConvertAll(w => w.GetDisplayText()));
        return $"{reference.GetDisplayText()} - {scriptureText}";
    }
}

// Program class for user interaction
class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John", 3, 16, "For God so loved the world that he gave his only begotten Son");
        
        Console.WriteLine(scripture.GetDisplayText());
        
        while (true)
        {
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            
            scripture.HideRandomWords(2);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
