public class Activity
{
    protected DateTime date;
    protected int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        throw new NotImplementedException();
    }

    public virtual double GetPace()
    {
        throw new NotImplementedException();
    }

    public virtual string GetSummary()
    {
        string activityType = this.GetType().Name;
        string summary = $"{date.ToString("dd MMM yyyy")} {activityType} ({minutes} min)";
        return summary;
    }
}