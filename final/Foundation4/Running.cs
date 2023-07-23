public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        double speedInMph = (distance / minutes) * 60.0;
        return speedInMph;
    }

    public override double GetPace()
    {
        double paceInMinPerMile = minutes / distance;
        return paceInMinPerMile;
    }

    public override string GetSummary()
    {
        string summary = base.GetSummary();
        summary += $"- Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        return summary;
    }
}

