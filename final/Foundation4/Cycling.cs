public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        double distanceInMiles = (speed * minutes) / 60.0;
        return distanceInMiles;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        double paceInMinPerMile = 60.0 / speed;
        return paceInMinPerMile;
    }

    public override string GetSummary()
    {
        string summary = base.GetSummary();
        summary += $"- Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        return summary;
    }
}
