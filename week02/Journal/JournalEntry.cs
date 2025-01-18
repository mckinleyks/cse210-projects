public class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(string prompt, string response)
    {

        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static JournalEntry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        if (parts.Length == 3)
        {
            return new JournalEntry(parts[1], parts[2]) { Date = parts[0] };
        }
        throw new FormatException("Invalid entry format.");
        
    }
}