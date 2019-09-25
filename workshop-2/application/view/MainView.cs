using System;

namespace application
{
  class MainView
  {
    public int showMenu()
    {
      int number;

      Console.WriteLine("1. Add new member");
      Console.WriteLine("2. View all members");
      Console.WriteLine("3. Remove a member");
      Console.WriteLine("4. Change a member's details");
      Console.WriteLine("5. Search for member");
      Console.WriteLine("6. Exit");

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
      Console.WriteLine("\n" + message + "\n");
    }

    public void print(string message)
    {
      Console.WriteLine("\n" + message + "\n");
    }

    public int renderMemberListType()
    {
      int number;

      Console.WriteLine("1. Compact List");
      Console.WriteLine("2. Verbose List");

      number = int.Parse(Console.ReadLine());
      return number;
    }

    public int getMemberToRemove()
    {
      int id;

      Console.Write("Enter ID of member to remove: ");
      id = int.Parse(Console.ReadLine());
      return id;
    }

    public int getMemberToEdit()
    {
      int id;

      Console.Write("Enter ID of member to edit: ");
      id = int.Parse(Console.ReadLine());
      return id;
    }
  }
}
