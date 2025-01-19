using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();

    private List<string> _prompts = new List<string>

    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.WriteLine("\nHow are you feeling today?");
        Console.WriteLine("1. 😊 Happy");
        Console.WriteLine("2. 😟 Stressed");
        Console.WriteLine("3. 😴 Tired");
        Console.WriteLine("4. 🤨 Confused");
        Console.WriteLine("5. 😒 Annoyed");
        Console.WriteLine("6. 😢 Sad");
        Console.WriteLine("7. 😍 In Love");
        Console.WriteLine("8. 🤮 Sick");
        Console.Write("Choose a number to represent your mood: ");
        string moodChoice = Console.ReadLine();

        string mood = moodChoice switch
        {
            "1" => "😊 Happy",
            "2" => "☹️ Stressed",
            "3" => "😴 Tired",
            "4" => "🤨 Confused",
            "5" => "😒 Annoyed",
            "6" => "😢 Sad",
            "7" => "😍 In Love", 
            "8" => "🤮 Sick",
            _ => "Unknown mood" 
        };


        JournalEntry newEntry = new JournalEntry(prompt, response, mood);
        _entries.Add(newEntry);

        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        Console.WriteLine("\n--- Journal ENtries ---");
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter the filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine("Journal save successfully!\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            _entries.Add(JournalEntry.FromFileFormat(line));
        }

        Console.WriteLine("Journal loaded successfully!\n");
    }
    
}
