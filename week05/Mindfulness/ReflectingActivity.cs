using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{

    private static readonly List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> questions = new List<string>
    {
        "Why was this experience meaninful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Reflect();
    }

    public void Reflect()
    {
        Console.WriteLine("Consider the following promt: ");
        Console.WriteLine();
        Random rand = new Random();
        string randomPrompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(" --- " + randomPrompt + " --- ");

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        List<string> shuffledQuestions = new List<string>(questions);
        ShuffleList(shuffledQuestions);

                    
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in : ");
        ShowCountdown(5);

        int questionIndex = 0;
        while (DateTime.Now < endTime)
        {
            if (questionIndex >= shuffledQuestions.Count)
            {
                questionIndex = 0;
                ShuffleList(shuffledQuestions);
            }

            Console.WriteLine(shuffledQuestions[questionIndex]);
            ShowSpinner(9);

            questionIndex++;
        }

        EndActivity();
    }

    private void ShuffleList(List<string> list)
    {
        Random rand = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}