public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordProgress() => Points;
    public override string GetStatus() => "[\u221E]";
    public override string Serialize() => $"EternalGoal,{Name},{Description},{Points}";

       public void SetCompleted(bool completed)
    {
        IsCompleted = completed;
    }
}

