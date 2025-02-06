using System;
using System.Threading;
using System.Collections.Generic;

public class Activity 
{
   public string Name {get; set; }
   public string Description { get; set; }
   public int Duration { get; set; } 

   public virtual void StartActivity()
   {
        Console.WriteLine();
        Console.WriteLine($"Starting {Name}: {Description}");
        Console.WriteLine();
        Console.Write("Please enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

    }

   public virtual void EndActivity()
   {
    Console.WriteLine($"Well done! You've completed {Duration}seconds of the {Name}.");
    ShowSpinner(3);
   }

   public void ShowCountdown(int seconds)
   {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
        Console.Clear();
   }


    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(500);
            Console.Write("\b\b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }

        Console.Clear();
    }
}




