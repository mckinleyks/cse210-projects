using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding.");

        bool userQuit = false;
        
        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            scripture.DisplayScripture();

            Console.WriteLine("\nPress Enter to continue or type 'quit' to expit the program.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                userQuit = true;
                break;
            }

            scripture.HideRandomWords();
        
        }

        Console.Clear();
        scripture.DisplayScripture();

        if (userQuit)
        {
        Console.WriteLine("\nYou want to quit the program. Goodbye!");
        }
        else
        {
        Console.WriteLine("\nAll words are now hidden. Goodbye.");
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse == -1 ? startVerse : endVerse;
    }


    public override string ToString()
    {
        return EndVerse == StartVerse
            ? $"{Book} {Chapter}:{StartVerse}"
            : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";

    }
}

class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayScripture()
    {

        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words.Select(word => word.Display())));
    }

    public void HideRandomWords ()
    {
        Random random = new Random();
        var wordsToHide = Words.Where(word => !word.IsHidden).ToList();

        int wordsToHideCount = Math.Min(3, wordsToHide.Count);

        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index = random.Next(wordsToHide.Count);
            wordsToHide[index].Hide();
            wordsToHide.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return Words.All(word => word.IsHidden);
    }
}

class Word
{
    private string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
            Text = text;
            IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}