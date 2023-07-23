using System;
using System.IO;

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string[] tokens) : base(tokens)
    {
        this.rsvpEmail = tokens[8];
    }

    public override string GetFullDetails()
    {
        return $"Reception - {base.GetFullDetails()} - RSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescriptions()
    {
        return $"{GetType().Name} - {title} - {time} - RSVP Email: {rsvpEmail}";
    }
}