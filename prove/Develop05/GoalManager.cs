// Start - This is the "main" function for this class. It is called by Program.cs, and then runs the menu loop.
// DisplayPlayerInfo - Displays the players current score.
// ListGoalNames - Lists the names of each of the goals.
// ListGoalDetails - Lists the details of each goal (including the checkbox of whether it is complete).
// CreateGoal - Asks the user for the information about a new goal. Then, creates the goal and adds it to the list.
// RecordEvent - Asks the user which goal they have done and then records the event by calling the RecordEvent method on that goal.
// SaveGoals - Saves the list of goals to a file.
// LoadGoals - Loads the list of goals from a file.

class GoalManager
{
  List<Goal> goals;
  int playerScore;

  public GoalManager()
  {
    goals = new List<Goal>();
    playerScore = 0;
  }


  public void DisplayPlayerInfo()
  {
    Console.WriteLine($"You have {playerScore} points.");
  }

public void ListGoalDetails()
{
    if (goals.Count == 0)
    {
        Console.WriteLine("No goals have been created yet.");
    }
    else
    {
        Console.WriteLine("The goals are:");
        int goalNumber = 1;
        foreach (Goal goal in goals)
        {
            string goalType = goal.GetType().Name.Replace("Goal", "");
            string name = goal.Name;
            string description = goal.Description;
            int points = goal.Points;

            if (goal is ChecklistGoal checklistGoal)
            {
                int target = checklistGoal.Target;
                int bonus = checklistGoal.Bonus;
                int progress = checklistGoal.Progress;
                Console.WriteLine($"{goalNumber}. {goal.GetCheckboxString()} {goalType}: Name: {name}, Description: {description}, Points: {points}, Target: {target}, Bonus: {bonus}, Progress: {progress}/{target}");
            }
            else
            {
                Console.WriteLine($"{goalNumber}. {goal.GetCheckboxString()} {goalType}: Name: {name}, Description: {description}, Points: {points}");
            }
            goalNumber++;
        }
    }
}



public void CreateGoal()
{
      Console.WriteLine("The types of Goals are:");
      Console.WriteLine(" 1. Simple Goal");
      Console.WriteLine(" 2. Eternal Goal");
      Console.WriteLine(" 3. Checklist Goal");
      Console.Write("Which type of goal would you like to create? ");
      int goalType = int.Parse(Console.ReadLine());

      if (goalType == 1 || goalType == 2 || goalType == 3)
      {
          Console.Write("What is the name of your goal? ");
          string name = Console.ReadLine();

          Console.Write("What is a short description of it? ");
          string description = Console.ReadLine();

          Console.Write("What is the amount of points associated with this goal? ");
          int points = int.Parse(Console.ReadLine());

          if (goalType == 1)
          {
              goals.Add(new SimpleGoal(name, description, points));
          }
          else if (goalType == 2)
          {
              goals.Add(new EternalGoal(name, description, points));
          }
          else if (goalType == 3)
          {
              Console.Write("How many times does this goal need to be accomplished for a bonus? ");
              int target = int.Parse(Console.ReadLine());

              Console.Write("What is the bonus for accomplishing it that many times? ");
              int bonus = int.Parse(Console.ReadLine());

              goals.Add(new ChecklistGoal(name, description, points, target, bonus));
          }
      
      }

}



public void RecordEvent()
{
    if (goals.Count == 0)
    {
        Console.WriteLine("No goals have been created yet.");
    }
    else
    {
        Console.WriteLine("Goals:");
        int goalNumber = 1;
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"{goalNumber}. {goal.Name}");
            goalNumber++;
        }

        Console.Write("Enter the number of the goal you want to record an event for: ");
        int selectedGoalNumber = int.Parse(Console.ReadLine());

        if (selectedGoalNumber >= 1 && selectedGoalNumber <= goals.Count)
        {
            Goal selectedGoal = goals[selectedGoalNumber - 1];
            selectedGoal.RecordEvent();
            playerScore += selectedGoal.Points;
            Console.WriteLine($"Event recorded for goal: {selectedGoal.Name}");
            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"Progress: {checklistGoal.Progress}/{checklistGoal.Target}");
                if (checklistGoal.IsComplete())
                {
                    playerScore += checklistGoal.Bonus;
                    Console.WriteLine($"Bonus points earned: {checklistGoal.Bonus}");
                }
            }
            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
}




public void SaveGoals()
{
    Console.Write("What is the filename for the goal file? ");
    string filePath = Console.ReadLine();

    using (StreamWriter writer = new StreamWriter(filePath))
    {
        writer.WriteLine(playerScore);

        foreach (Goal goal in goals)
        {
            string goalType = goal.GetType().Name;
            string name = goal.Name;
            string description = goal.Description;
            int points = goal.Points;

            if (goal is ChecklistGoal checklistGoal)
            {
                int target = checklistGoal.Target;
                int bonus = checklistGoal.Bonus;
                int progress = checklistGoal.Progress;
                writer.WriteLine($"{goalType}: Name: {name}, Description: {description}, Points: {points}, Target: {target}, Bonus: {bonus}, Progress: {progress}");
            }
            else
            {
                writer.WriteLine($"{goalType}: Name: {name}, Description: {description}, Points: {points}");
            }
        }
    }
}

public void LoadGoals()
{
    Console.Write("What is the filename for the goal file? ");
    string filePath = Console.ReadLine();

    if (File.Exists(filePath))
    {
        goals.Clear();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                playerScore = int.Parse(line);
            }

            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("SimpleGoal:"))
                {
                    string[] data = line.Split(new string[] { ": Name: ", ", Description: ", ", Points: " }, StringSplitOptions.None);
                    string name = data[1];
                    string description = data[2];
                    int points = int.Parse(data[3]);
                    goals.Add(new SimpleGoal(name, description, points));
                }
                else if (line.StartsWith("EternalGoal:"))
                {
                    string[] data = line.Split(new string[] { ": Name: ", ", Description: ", ", Points: " }, StringSplitOptions.None);
                    string name = data[1];
                    string description = data[2];
                    int points = int.Parse(data[3]);
                    goals.Add(new EternalGoal(name, description, points));
                }
                else if (line.StartsWith("ChecklistGoal:"))
                {
                    string[] data = line.Split(new string[] { ": Name: ", ", Description: ", ", Points: ", ", Target: ", ", Bonus: ", ", Progress: " }, StringSplitOptions.None);
                    string name = data[1];
                    string description = data[2];
                    int points = int.Parse(data[3]);
                    int target = int.Parse(data[4]);
                    int bonus = int.Parse(data[5]);
                    int progress = int.Parse(data[6]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                    checklistGoal.Progress = progress;
                    goals.Add(checklistGoal);
                }
            }
        }
    }
    else
    {
        Console.WriteLine("File not found: " + filePath);
    }
}




  
}
