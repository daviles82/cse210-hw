using System;
using System.IO;

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string[] tokens) : base(tokens)
    {
        this.weatherForecast = tokens[8];
    }

    public override string GetFullDetails()
    {
        return $"Outdoor Gathering - {base.GetFullDetails()} - Weather Forecast: {weatherForecast}";
    }
}