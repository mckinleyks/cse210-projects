using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,101);

        int guess;

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

    
            if (guess < number)
            {
                Console.WriteLine("Higher");
            } 
            else if (guess > number)
            {
                Console. WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed the right number!");
            }

        }

        while (guess != number);

    }


}