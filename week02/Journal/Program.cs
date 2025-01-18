using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string date = DateTime.Now.ToShortDateString();
        JournalEntry entry = new JournalEntry("Prompt", "Response");

        while (true)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                case "2":
                    myJournal.DisplayEntries();
                    break;
                case "3":
                    myJournal.SaveToFile();
                    Console.WriteLine("Journal save successfully!");
                    break;
                case "4":
                    myJournal.LoadFromFile();
                    Console.WriteLine("Journal loaded successfully!");
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1-5.");
                    break;
            }
        }
    }
}