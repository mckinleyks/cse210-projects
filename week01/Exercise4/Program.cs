using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        while (number !=0);

        int sum = 0;
        foreach (int numb in numbers)
        {
            sum += numb;
        }

        double average = (double)sum / numbers.Count;
        int largest = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }

}