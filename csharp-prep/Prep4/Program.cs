using System;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>();

        int number = -1;


        while (number != 0)
        {

        Console.Write("Enter a number individually, type 0 when complete: ");
        string userNumber = Console.ReadLine();
        number = int.Parse(userNumber);
        numbers.Add(number);
        }
        if (number == 0)
        {
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        int stageCount = numbers.Count;
        int count = stageCount - 1;
        int average = sum / count;
        Console.WriteLine($"The average is: {average}");

        Console.WriteLine($"The Largest number is: {numbers.Max()}");

        Console.WriteLine($"The smallest positive number is: {numbers.Where(i => i > 0).Min()}");
        }
    }
}