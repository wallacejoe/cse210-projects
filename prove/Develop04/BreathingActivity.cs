using System;

public class BreathingActivity : Activity
{
    //I added a another method to loop through the Displays and
    //keep track of the time. I realized the breathe methods would
    //be hard pressed to accomplish this task themselves.
    public void RunBreaths()
    {
        DateTime futureTime = DateTime.Now.AddSeconds(_duration);

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            DisplayBreatheIn();
            DisplayBreatheOut();
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
    }

    //I made the breathe methods private, since the RunBreaths method
    //already takes care of calling these methods.
    private void DisplayBreatheIn()
    {
        Console.Write("Breathe in...");
        PauseCountdown(4);
        Console.WriteLine();
    }
    private void DisplayBreatheOut()
    {
        Console.Write("Now breathe out...");
        PauseCountdown(6);
        Console.WriteLine();
    }

    /*Constructor*/
    public BreathingActivity(string name, string description, int duration) : base(name, description, duration){}
}