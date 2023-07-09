using System;

class Program
{
    static void Main(string[] args)
    {   
        int userMenuInput = 0;

        List<string> menu = new List<string>
        {
            "Menu Options:",
            " 1. Start breathing activity",
            " 2. Start reflecting activity",
            " 3. Start listening activity",
            " 4. Quit"
        };

        
        while (userMenuInput != 4)
        {
            Console.Clear();
            foreach (string menuItem in menu)
            {
                Console.WriteLine(menuItem);
            }
            Console.Write("Select a choice from the menu: ");
            userMenuInput = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (userMenuInput)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case 3:
                    ListeningActivity listeningActivity = new ListeningActivity();
                    listeningActivity.Run();
                    break;
                    
            }
        }
    }
}