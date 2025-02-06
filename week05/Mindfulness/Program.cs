using System;

class Program
{
    static void Main(string[] args)
    {
        Activity breathingActivity = new BreathingActivity();
        Activity reflectingActivity = new ReflectingActivity();
        Activity listingActivity = new ListingActivity();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App");
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Please choose an option: "); 

            string choice = Console.ReadLine().Trim();


            if (choice == "1")
            {
                Console.Clear();
                Console.WriteLine("You selected Breathing Activity.");
                breathingActivity.StartActivity();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("You selected Reflection Activity.");
                reflectingActivity.StartActivity();
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("You selected Listing Activity.");
                listingActivity.StartActivity();
            }
            else if (choice == "4")
            {
                Console.WriteLine("You are now quitting. Goodbye.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

}
        

    

