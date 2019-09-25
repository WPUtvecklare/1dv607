using System;

namespace application
{
  class MainView
  {
    public int showMenu()
    {
      int number;

      Console.WriteLine("1. Add new member");
      Console.WriteLine("2. Remove a member");
      Console.WriteLine("3. Change a member's details");
      Console.WriteLine("4. Exit");

      number = int.Parse(Console.ReadLine());
      return number;
    }

    public string enterName()
    {
      string newName;

      Console.Write("Enter name: ");
      newName = Console.ReadLine();
      return newName;
    }

    public string enterPin()
    {
      string pin;

      Console.Write("Enter personal number (10 numbers): ");
      pin = Console.ReadLine();
      return pin;
    }

    public void printMessage(string message)
    {
      Console.WriteLine(message);
    }
  }
}
