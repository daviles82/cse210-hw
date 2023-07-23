using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("events.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] tokens = line.Split('|');

                Event ev = CreateEvent(tokens);
                if (ev != null)
                {
                    Console.WriteLine(ev.GetStandardDetails());
                    Console.WriteLine(ev.GetFullDetails());
                    Console.WriteLine(ev.GetShortDescriptions());
                    Console.WriteLine();
                }
            }
        }
    }

    private static Event CreateEvent(string[] tokens)
    {
        if (tokens.Length < 1 || string.IsNullOrEmpty(tokens[0].Trim()))
        {
            return null;
        }

        string type = tokens[0];
        switch (type)
        {
            case "Lecture":
                return new Lecture(tokens);
            case "Reception":
                return new Reception(tokens);
            case "OutdoorGathering":
                return new OutdoorGathering(tokens);
            default:
                throw new ArgumentException("Unknown event type: " + type);
        }
    }
}
