using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int SquredNumber = SqureNumber(userNumber);

        DisplayResult(userName, SquredNumber);

    }
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;

    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string userNumb = Console.ReadLine();
        int userNumber = int.Parse(userNumb);

        return userNumber;
    }

    static int SqureNumber(int userNumber)
    {
        int square = userNumber * userNumber;
        return square;
    }

    static void DisplayResult(string userName, int square)
    {
        Console.WriteLine($"{userName}, the square of your number is {square}");
    }

}