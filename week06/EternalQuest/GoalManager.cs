using System.Security.Cryptography.X509Certificates;

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    public int GoalCount => goals.Count;
    public int TotalScore { get; private set; }

    public void AddGoal(Goal goal) => goals.Add(goal);
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < goals.Count)
            TotalScore += goals[index].RecordProgress();
    }
    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()} {goals[i].Name}");
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(TotalScore);
            foreach (var goal in goals)
                writer.WriteLine(goal.Serialize());
        }
    }
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            TotalScore = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts[0] == "SimpleGoal")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goal.SetCompleted(bool.Parse(parts[4]));
                    goals.Add(goal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    var goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    goals.Add(goal);
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[6]));
                    goal.SetCurrentCount(int.Parse(parts[5]));
                    goals.Add(goal);
                }
                   
            }
        }
    }
    public void ClearGoals()
    {
        goals.Clear();
        TotalScore = 0;
        File.Delete("goals.txt");
    }
}