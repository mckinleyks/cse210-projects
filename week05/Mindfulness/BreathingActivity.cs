using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void StartActivity()
    {
        base.StartActivity();
        BreatheInOut();
    }

    public void BreatheInOut()
    {
        int breathInDuration = 4;
        int breathOutDuration = 4;
        int totalBreathingDuration = breathInDuration + breathOutDuration;
        int totalCycles = Duration / totalBreathingDuration;

        Console.Clear();
        Console.WriteLine("Get ready for your breathing exercise...");
        Thread.Sleep(2000);
        
        for (int i = 0; i < totalCycles; i++)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            ShowCountdown(breathInDuration);

            Console.Clear();
            Console.WriteLine("Now breath out...");
            ShowCountdown(breathOutDuration);
        }


        EndActivity();
    }

}