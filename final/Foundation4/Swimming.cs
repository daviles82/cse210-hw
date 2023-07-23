public class Swimming : Activity
{
    private int laps;
    private double lapLengthMiles = 50.0 / 1000.0 * 0.62;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * lapLengthMiles;
    }

    public override double GetSpeed()
    {
        double speedInMph = (GetDistance() / (minutes / 60.0));
        return speedInMph;
    }

    public override double GetPace()
    {
        double paceInMinPerMile = minutes / GetDistance();
        return paceInMinPerMile;
    }

    public override string GetSummary()
    {
        string summary = base.GetSummary();
        summary += $"- Distance: {GetDistance():F1} miles, Laps: {laps}, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        return summary;
    }
}
