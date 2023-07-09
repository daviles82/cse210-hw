
class ListeningActivity: Activity
{

  class ListeningPromptGenerator 
  {
    List<string> prompts;


    public ListeningPromptGenerator()
    {
      prompts = new List<string>
      {
        " ---Who are people that you appreciate? ---",
        " ---What are personal strengths of yours? ---",
        " ---Who are people that you have helped this week? ---",
        " ---When have you felt the Holy Ghost this month? ---",
        " ---Who are some of your personal heroes? ---"
      };
    }

    public string GetRandomPrompt()
    {
      string randomPrompt = "";
      int randomIndex = new Random().Next(prompts.Count);

      randomPrompt = prompts[randomIndex];

      return randomPrompt;
    }

  } 
  public ListeningActivity()
  {
    this.SetActivityName("Listening Activity");
    this.SetDescription("This activity will help you reflect on the good things in your " +
    "life by having you list as many things as you can in a certain area.");
  }
  ListeningPromptGenerator listeningPromptGenerator = new ListeningPromptGenerator();
    public void Run()
  {
    DisplayStartingMessage();
    int timeduration = GetDuration();

    {
      Console.WriteLine();
      Console.WriteLine("List as many responses you can to the following prompt:");
      string prompt = listeningPromptGenerator.GetRandomPrompt();
      Console.WriteLine(prompt);
      Console.Write("You may begin in: ");
      ShowCountDown(5);
      Console.WriteLine();

      System.Timers.Timer timer = new System.Timers.Timer(1000);
      timer.Elapsed += (sender, e) => timeduration--;
      timer.Start();
      int counter = 0;
      while (true)
      {
        Console.Write("> ");
        string response = Console.ReadLine();
        counter++;
        if (timeduration <= 0)
        {
          timer.Stop();
          break;
        }
      }
      Console.WriteLine($"You listed {counter} items!");
    }
    DisplayEndingMessage();
  }
}
