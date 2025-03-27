using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments { get; set; } = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("C# Basics", "John Doe", 600);
        Video video2 = new Video("Advanced OOP", "Jane Smith", 1200);
        Video video3 = new Video("Design Patterns", "Alice Johnson", 900);

        // Adding comments to video1
        video1.AddComment(new Comment("Mike", "Great explanation!"));
        video1.AddComment(new Comment("Emma", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Liam", "I finally understand C#!"));

        // Adding comments to video2
        video2.AddComment(new Comment("Sophia", "Can you make a part 2?"));
        video2.AddComment(new Comment("James", "Very clear and detailed."));
        video2.AddComment(new Comment("Olivia", "This is exactly what I needed!"));

        // Adding comments to video3
        video3.AddComment(new Comment("Lucas", "Design patterns explained perfectly!"));
        video3.AddComment(new Comment("Ava", "This makes so much sense now."));
        video3.AddComment(new Comment("Ethan", "Best tutorial on this topic!"));

        // Adding videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
