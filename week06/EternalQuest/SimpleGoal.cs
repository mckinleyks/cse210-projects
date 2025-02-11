public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordProgress()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Points;
        }
        return 0;
    }

    public void SetCompleted(bool completed)
    {
        IsCompleted = completed;
    }
    public override string GetStatus() => IsCompleted ? "[X]" : "[]";
    public override string Serialize() => $"SimpleGoal,{Name},{Description},{Points},{IsCompleted}";
}
