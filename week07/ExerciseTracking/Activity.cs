using System;

public abstract class Activity
{
    private DateTime date;
    private double duration;

    public Activity(DateTime date, double duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public DateTime Date => date;
    public double Duration => duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {this.GetType().Name} ({duration} min): Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}