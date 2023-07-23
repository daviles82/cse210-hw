using System;
using System.IO;

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string[] tokens) : base(tokens)
    {
        this.speaker = tokens[8];
        this.capacity = int.Parse(tokens[9]);
    }

    public override string GetFullDetails()
    {
        return $"Lecture - {base.GetFullDetails()} - Speaker: {speaker} - Capacity: {capacity}";
    }

    public override string GetShortDescriptions()
    {
        return $"{GetType().Name} - {title} - {time} - Speaker: {speaker}";
    }
}