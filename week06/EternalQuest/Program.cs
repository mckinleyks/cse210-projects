using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        string filename = "goals.txt";
        manager.LoadFromFile(filename);

        
        while (true)
        {
            Console.WriteLine($"\nYou have {manager.TotalScore} points.");
            Console.WriteLine();
            Console.Write("Menu Options: ");
            Console.WriteLine("\n1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event \n6. Quit\n7. Clear Goals:");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {

                Console.WriteLine("The types of Goals are: ");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.Write("Which type of Goal would you like to create? ");

                if (int.TryParse(Console.ReadLine(), out int type) && type >= 1 && type <= 3)
                {
                    Console.WriteLine("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Enter points: ");

                    if (int.TryParse(Console.ReadLine(), out int points))
                    {
                        if (type == 1)
                            manager.AddGoal(new SimpleGoal(name, desc, points));
                        else if (type == 2)
                            manager.AddGoal(new EternalGoal(name, desc, points));
                        else if (type == 3)
                        {
                            Console.Write("Enter target count: ");
                            if (int.TryParse(Console.ReadLine(), out int targetCount))
                            {
                                Console.Write("Enter bonus: ");
                                if (int.TryParse(Console.ReadLine(), out int bonus))
                                {
                                    manager.AddGoal(new ChecklistGoal(name, desc, points, targetCount, bonus));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid bonus value.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid target count.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid points value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid goal type. Please enter 1, 2, or 3.");
                }
            }
            
            else if (choice == "2")
                manager.DisplayGoals();
            
            else if (choice == "3")
            {
                manager.SaveToFile(filename);
                Console.WriteLine("Goals saved successfully.");
            }

            else if (choice == "4")
            {
                manager.LoadFromFile(filename);
                Console.WriteLine("Goals loaded successfully.");
            }
            else if (choice == "5")
            {
                manager.DisplayGoals();
                Console.Write("Enter goal number to record: ");
                
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= manager.GoalCount)
                {
                    manager.RecordEvent(num - 1);
                    Console.WriteLine("Progress recorded.");
                }
                else
                {
                    Console.WriteLine("Invalid goal number. Please try again.");
                }
            }
            else if (choice == "6")
            {
                manager.SaveToFile(filename);
                Console.WriteLine("Goals saved. Exiting program.");
                break;
            }

            else if (choice == "7")
            {
                manager.ClearGoals();
                Console.WriteLine("All goals have been cleared. Starting fresh.");
            }
            
            else 
            {            
                Console.WriteLine("Invalid choice. Please select a number from the menu.");
            
            }
        }
    }
}