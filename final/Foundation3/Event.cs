public class Event
{
    protected string title, description, time;
    protected Address address;

    public Event(string[] tokens)
    {
        this.title = tokens[1];
        this.description = tokens[2];
        this.time = tokens[3];
        this.address = new Address(tokens[4], tokens[5], tokens[6], tokens[7]);
    }

    public string GetStandardDetails()
    {
        return $"{title} - {description} - {time} - {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"{title} - {description} - {time} - {address.GetFullAddress()}";
    }

    public virtual string GetShortDescriptions()
    {
        return $"{GetType().Name} - {title} - {time}";
    }
}