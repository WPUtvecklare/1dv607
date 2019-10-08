using System;

namespace application
{
    class MainView
    {
        public MainMenu showMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add new member");
                Console.WriteLine("2. View all members");
                Console.WriteLine("3. Remove a member");
                Console.WriteLine("4. Change a member's details");
                Console.WriteLine("5. Search for member");
                Console.WriteLine("6. Add boat");
                Console.WriteLine("7. Remove a boat");
                Console.WriteLine("8. Change boat details");
                Console.WriteLine("9. Save & Exit\n");

                int number = tryParseConsole();

                if (number <= 9 && number >= 1)
                {
                    return (MainMenu)number;
                }
                else
                {
                    printMessage("Choose a value between 1 and 9");
                }
            }
        }

        public void printMessage(string message)
        {
            Console.WriteLine("\n" + message + "\n");
        }

        public void render(string content)
        {
            Console.WriteLine("\n" + content + "\n");
        }

        public int tryParseConsole()
        {
            int answer = 0;

            try
            {
                answer = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                printMessage("Not a valid value");
            }
            return answer;
        }
    }
}
