public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int Bonus { get; private set; }

    public void SetCompleted(bool completed)
    {
        IsCompleted = completed;
    }

    public void SetCurrentCount(int count)
    {
        CurrentCount = count; 
    }



    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override int RecordProgress()
    {
        if (IsCompleted) return 0;
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                return Points + Bonus;
            }
            return Points;
        }
        return 0;
    }
    public override string GetStatus() => IsCompleted ? "[X]" : $"[{CurrentCount}/{TargetCount}]";
    public override string Serialize() => $"ChecklistGoal,{Name},{Description},{Points},{TargetCount},{CurrentCount},{Bonus}";

}