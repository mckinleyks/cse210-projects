using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment("john Doe", "Math - Algebra");
        Console.WriteLine(myAssignment.GetSummary());

        MathAssignment mathHomework = new MathAssignment("Alice Johnson", "Calculus", "5.3", "1-10, 15-20");
        Console.WriteLine(mathHomework.GetSummary());
        Console.WriteLine(mathHomework.GetHomeworkList());

        WritingAssignment essay = new WritingAssignment("Mary Waters", "History", "The Causes of WorldWar II");
        Console.WriteLine(essay.GetSummary());
        Console.WriteLine(essay.GetWritingInformation());
    }

}