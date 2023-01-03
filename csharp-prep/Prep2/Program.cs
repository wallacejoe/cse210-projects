using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Grade: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Well done, you have successfully passed the class.");
        }
        else
        {
            Console.WriteLine("You have not passed the class, better luck next time.");
        }
    }
}