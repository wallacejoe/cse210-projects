using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        float userInput = 1;
        List<float> numbers = new List<float>();
        float sum = 0;
        float average = 0;
        float largest = 0;
        float smallest = 0;

        do
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            numbers.Add(userInput);
        } while (userInput != 0);

        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
            if (numbers[i] > largest)
            {
                largest = numbers[i];
            }
            if (numbers[i] < smallest && numbers[i] > 0)
            {
                smallest = numbers[i];
            }
        }

        smallest = largest;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] < smallest && numbers[i] > 0)
            {
                smallest = numbers[i];
            }
        }

        average = sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
    }
}