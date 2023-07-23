using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        double lapLengthMiles = 50.0 / 1000.0 * 0.62;

        try
        {
            string logFilePath = "activitylog.txt";
            string[] lines = File.ReadAllLines(logFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    string activityType = parts[0].Trim().ToLower();
                    string[] dataParts = parts[1].Split('|');

                    double distance = 0;
                    double speed = 0;
                    double pace = 0;

                    foreach (string dataPart in dataParts)
                    {
                        string[] keyValue = dataPart.Split(',');
                        if (keyValue.Length >= 2)
                        {
                            string key = keyValue[0].Trim().ToLower();
                            string value = keyValue[1].Trim();

                            switch (key)
                            {
                                case "distance":
                                    distance = double.Parse(value.Split(' ')[0]);
                                    break;
                                case "speed":
                                    speed = double.Parse(value.Split(' ')[0]);
                                    break;
                                case "pace":
                                    if (!string.IsNullOrEmpty(value))
                                        pace = double.Parse(value.Split(' ')[0]);
                                    break;
                            }
                        }
                    }

                    switch (activityType)
                    {
                        case "swimming":
                            activities.Add(new Swimming(DateTime.Now, (int)(distance / speed * 60), (int)(distance / lapLengthMiles)));
                            break;
                        case "cycling":
                            activities.Add(new Cycling(DateTime.Now, (int)(distance / speed * 60), speed));
                            break;
                        case "running":
                            activities.Add(new Running(DateTime.Now, (int)(distance / speed * 60), distance));
                            break;
                        default:
                            Console.WriteLine($"Unknown activity type: {activityType}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Error parsing line: {line}");
                }
            }

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the activity log file: {ex.Message}");
        }
    }
}



