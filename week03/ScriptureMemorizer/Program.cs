using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine hear and lean not unto thine own understanding."),
            new Scripture(new Reference("D&C", 121, 7), "My son, peace be unto thy soul; thine adversity and thine afflictions shall be but a small moment."),
            new Scripture(new Reference("Ether", 5, 5), "And if it so be that they repent and come unto the Father in the name of Jesus, they shall be received into the kingdom of God."),
            new Scripture(new Reference("Mosiah", 3, 3), "He is despised and rejected of man; a man of sorrows, and acquainted with grief; and we hid as it were our faces from him; he was despised, and we esteemed him not."),
        };

        Random random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        bool userQuit = false;
        
        while (!selectedScripture.IsFullyHidden())
        {
            Console.Clear();
            selectedScripture.DisplayScripture();

            Console.WriteLine("\nPress Enter to continue or type 'quit' to expit the program.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                userQuit = true;
                break;
            }

            selectedScripture.HideRandomWords();
        
        }

        Console.Clear();
        selectedScripture.DisplayScripture();

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



