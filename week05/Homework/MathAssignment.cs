public class MathAssignment: Assignment
{
    private string _textSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textSection, string problems)
        : base(studentName, topic)
    {
        _textSection = textSection;
        _problems = problems;

    }

    public string GetHomeworkList()
    {
        return $"Section {_textSection} Problems {_problems}";
    }

}
