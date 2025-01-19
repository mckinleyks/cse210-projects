public class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public JournalEntry(string prompt, string response, string mood)
    {

        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood; {Mood}\n");
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}|{Mood}";
    }

    public static JournalEntry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        if (parts.Length == 4)
        {
            return new JournalEntry(parts[1], parts[2], parts[3]) { Date = parts[0] };
        }
        throw new FormatException("Invalid entry format.");
        
    }
}