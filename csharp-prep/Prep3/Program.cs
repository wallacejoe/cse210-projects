using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "";

        do
        {
            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(1, 101);

            int guess = -1;
            int numGuesses = 0;

            do
            {
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);

                numGuesses = numGuesses + 1;

                if (guess == magicNum)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numGuesses} guesses.");
                    Console.Write("Would you like to play again? ");
                    playAgain = Console.ReadLine();
                    Console.WriteLine();
                }
                else if (guess < magicNum)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNum)
                {
                    Console.WriteLine("Lower");
                }
            } while (guess != magicNum);
        } while (playAgain == "yes");
    }
}