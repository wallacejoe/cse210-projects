using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcom to the {_name}");
        Console.WriteLine($"\n{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        try
        {
            _duration = int.Parse(Console.ReadLine());
        } catch {}
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseSpinner(12);
        Console.WriteLine($"\n");
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine($"Well done!!");
        PauseSpinner(12);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        PauseSpinner(12);
    }

    //I was originally going to make these pause methods return a string,
    //but I realized it would save time to print directly from the method.
    public void PauseSpinner(int spinTime)
    {
        //This keeps track of the total number of spins.
        int numSpins = 0;
        //This determines which spin symbol to display.
        int spinNum = 1;

        Console.Write("|");
        while (spinTime >= numSpins)
        {
            if (spinNum == 1)
            {
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("/");
                spinNum += 1;
            }
            else if (spinNum == 2)
            {
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("-");
                spinNum += 1;
            }
            else if (spinNum == 3)
            {
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("\\");
                spinNum += 1;
            }
            else
            {
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("|");
                spinNum = 1;
            }
            numSpins += 1;
        }
        Console.Write("\b \b");
    }

    public void PauseCountdown(int spinTime)
    {
        Console.Write(spinTime);
        spinTime -= 1;
        while (spinTime > 0)
        {
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write(spinTime);
            spinTime -= 1;
        }
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }

    /*Constructor*/
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }
}