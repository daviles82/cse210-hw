using System;

class Program
{
    static void Main(string[] args)
    {   
        int userMenuInput = 0;
        GoalManager goalManager = new GoalManager();

        List<string> menu = new List<string>
        {            
            "Menu Options:",
            " 1. Create New Goal",
            " 2. List Goals",
            " 3. Save Goals",
            " 4. Load Goals",
            " 5. Record Event",
            " 6. Quit"
        };

        
        while (userMenuInput != 6)
        {   

            Console.WriteLine();
            goalManager.DisplayPlayerInfo();
            Console.WriteLine();
            foreach (string menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
            
            Console.Write("Select a choice from the menu: ");
            userMenuInput = int.Parse(Console.ReadLine());

            switch (userMenuInput)
            {
                case 1:
                    goalManager.CreateGoal();
                    break;
                case 2:
                    goalManager.ListGoalDetails();
                    break;
                case 3:
                    goalManager.SaveGoals();
                    break;
                case 4:
                    goalManager.LoadGoals();
                    break;
                case 5:
                    goalManager.RecordEvent();
                    break;                           
            }

        }
    }
}