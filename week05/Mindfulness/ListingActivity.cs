using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ListingActivity : Activity
{
    private static readonly List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void StartActivity()
    {
        base.StartActivity();
        ListItems();
    }

    public void ListItems()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        Random rand = new Random();
        string randomPrompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(" --- " + randomPrompt + " --- ");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine("Start Listing your answers...");

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }

}