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



