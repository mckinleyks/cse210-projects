using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract int RecordProgress();
    public abstract string GetStatus();
    public abstract string Serialize();
}
