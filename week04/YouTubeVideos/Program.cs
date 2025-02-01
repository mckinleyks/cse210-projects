using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Comment comment1 = new Comment("Billy", "Thanks for the insight.");
        Comment comment2 = new Comment("Sara", "Look forward to the next video!");
        Comment comment3 = new Comment("Vlad", "This was so fun to watch!");
        Comment comment4 = new Comment("Jimmy", "This was some great insight on working with emotion.");
        Comment comment5 = new Comment("Landon", "I couldn't stop laughing watching this!");

        Video video1 = new Video("How to convince your kids to pick up their toys", "Callie Johnson", 180);
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment5);

        Video video2 = new Video("When kids get really excited", "bob floral", 220);
        video2.AddComment(comment3);
        video2.AddComment(comment4);
        video2.AddComment(comment1);

        Video video3 = new Video("Life with kids", "Kenzie Johnson", 180);
        video3.AddComment(comment5);
        video3.AddComment(comment3);
        video3.AddComment(comment2);

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }

    }
}

class Video 
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length {get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
    
    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment 
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}