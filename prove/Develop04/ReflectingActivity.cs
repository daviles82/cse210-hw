
class ReflectingActivity: Activity
{


  class PromptGenerator 
  {
    List<string> prompts;


    public PromptGenerator()
    {
      prompts = new List<string>
      {
        " --- Think of a time when you stood up for someone else. ---",
        " --- Think of a time when you did something really difficult. ---",
        " --- Think of a time when you helped someone in need. ---",
        " --- Think of a time when you did something truly selfless. ---"
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

  class SecondPromptGenerator
  {
      List<string> secondPrompts;
      List<string> usedPrompts;

      public SecondPromptGenerator()
      {
          secondPrompts = new List<string>
          {
              "Why was this experience meaningful to you?",
              "Have you ever done anything like this before?",
              "How did you get started?",
              "How did you feel when it was complete?",
              "What made this time different than other times when you were not as successful?",
              "What is your favorite thing about this experience?",
              "What could you learn from this experience that applies to other situations?",
              "What did you learn about yourself through this experience?",
              "How can you keep this experience in mind in the future?"
          };
          usedPrompts = new List<string>();
      }

      public string GetRandomSecondPrompt()
      {
          if (secondPrompts.Count == 0)
          {
              secondPrompts.AddRange(usedPrompts);
              usedPrompts.Clear();
          }

          int randomIndex = new Random().Next(secondPrompts.Count);
          string randomPrompt = secondPrompts[randomIndex];
          secondPrompts.RemoveAt(randomIndex);
          usedPrompts.Add(randomPrompt);

          return randomPrompt;
      }
  }

  public ReflectingActivity()
  {
    this.SetActivityName("Reflecting Activity");
    this.SetDescription("This activity will help you reflect on times in your life when " +
    "you have shown strength and resilience. This will help you recognize the power you " +
    "have and how you can use it in other aspects of your life.");
  }
  PromptGenerator promptGenerator = new PromptGenerator();

  SecondPromptGenerator secondPromptGenerator = new SecondPromptGenerator();

  public void Run()
  {
    DisplayStartingMessage();
    int interval = GetDuration() / 2;
    {
      Console.WriteLine();
      Console.WriteLine("Consider the following prompt:");
      Console.WriteLine();
      string prompt = promptGenerator.GetRandomPrompt();
      Console.WriteLine(prompt);
      Console.WriteLine();
      Console.WriteLine("When you have something in mind, press enter to continue.");
      string response = Console.ReadLine();
      Console.WriteLine("Now ponder on each of the following questions as they related to " +
      "this experience");
      Console.Write("You may begin in: ");
      ShowCountDown(5);
      Console.Clear();
      Console.Write("> ");
      string secondPrompt = secondPromptGenerator.GetRandomSecondPrompt();
      Console.Write(secondPrompt);
      Console.Write(" ");
      ShowSpinner(interval);
      Console.WriteLine();
      Console.Write("> ");
      string thirdPrompt = secondPromptGenerator.GetRandomSecondPrompt();
      Console.Write(thirdPrompt);
      Console.Write(" ");
      ShowSpinner(interval);
      Console.WriteLine();
    }
    DisplayEndingMessage();
  }

}

