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
      Console.WriteLine("6. Add boat");
      Console.WriteLine("7. Exit");

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

    public void render(string content)
    {
      Console.WriteLine("\n" + content + "\n");
    }

    public int renderMemberListType()
    {
      int number;

      Console.WriteLine("1. Compact List");
      Console.WriteLine("2. Verbose List");

      number = int.Parse(Console.ReadLine());
      return number;
    }

    public int getMemberById()
    {
      int id;

      Console.Write("Enter ID: ");
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

    public int getWhichMemberToAssignABoat()
    {
      int answer = 0;
      Console.WriteLine("1. Select member from the member list");
      Console.WriteLine("2. Search for member");
      answer = int.Parse(Console.ReadLine());
      return answer;
    }

    public int getBoatType()
    {
      int answer = 0;
      System.Console.Write("Choose boat type: ");
      answer = int.Parse(Console.ReadLine());
      return answer;
    }

    public double askForBoatLength()
    {
      double answer = 0;
      System.Console.Write("Enter boat length: ");
      answer = double.Parse(Console.ReadLine());
      return answer;
    }
  }
}
