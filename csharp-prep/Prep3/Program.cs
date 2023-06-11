using System;

class Program
{
    static void Main(string[] args)
    {
        int guess = -1;

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);

            while (guess != number)
            {
            Console.Write("Guess the right number. ");
            string userGuess = Console.ReadLine();
            guess = int.Parse(userGuess);

            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess == number)
            {
                Console.WriteLine("You guessed right");
                Console.WriteLine("Would you like to play another game? ");
                string userPlayAgain = Console.ReadLine();

                if (userPlayAgain == "yes")
                {
                number = randomGenerator.Next(1, 100);
                }
                else if (userPlayAgain == "no")
                {
                Console.WriteLine("Thank you for participating.");
                }
            }
            
        }
    }
}