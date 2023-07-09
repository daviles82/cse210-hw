
class BreathingActivity : Activity
{
  public BreathingActivity()
  {
    this.SetActivityName("Breathing Activity");
    this.SetDescription("This activity will help you relax by walking you " +
      "through breathing in and out slowly. " +
      "Clear your mind and focus on your breathing");
  }

  public void Run()
  {
    DisplayStartingMessage();
    int interval = GetDuration() / 6;
    for (int i =0; i <= 2; i++)
    {
      Console.WriteLine();
      Console.Write("Breath in...");
      ShowCountDown(interval);
      Console.WriteLine();
      Console.Write("Breath out...");
      ShowCountDown(interval);
      Console.WriteLine();
    }
    DisplayEndingMessage();
  }
}

