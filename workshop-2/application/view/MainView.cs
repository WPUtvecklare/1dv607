using System;

namespace application
{
  class MainView
  {
    public int showMenu()
    {
      int number;
      int firstChoice = 1;
      int lastChoice = 4;

      while (true)
      {
        try
        {
          Console.WriteLine("1. Add new member");
          Console.WriteLine("2. Remove a member");
          Console.WriteLine("3. Change a member's details");
          Console.WriteLine("4. Exit");

          number = int.Parse(Console.ReadLine());

          if (!(number >= firstChoice && number <= lastChoice))
          {
            throw new ApplicationException();
          }

          if (number == 4)
          {
            Environment.Exit(0);
          }
          else
          {
            return number;
          }
        }
        catch (Exception)
        {
          Console.WriteLine($"\n Ange ett heltal mellan {firstChoice} och {lastChoice}. \n");
        }
      }
    }

    public string renderAddNewMember()
    {
      string newName;

      while (true)
      {
        try
        {
          Console.Write("Enter name: ");
          newName = Console.ReadLine();

          if (!(newName.Length >= 3 && newName.Length <= 15))
          {
            throw new ApplicationException();
          }
          return newName;
        }
        catch (Exception)
        {
          Console.WriteLine($"\n Ange ett namn mellan 3 och 15 bokstäver");
        }
      }
    }

    public int personalID()
    {
      int pin;

      while (true)
      {
        try
        {
          Console.Write("Enter personal number (10 numbers): ");
          pin = int.Parse(Console.ReadLine());

          if ((pin.ToString().Length != 10))
          {
            throw new ApplicationException();
          }
          return pin;
        }
        catch (Exception)
        {
          Console.WriteLine($"\n Ange ett personnummer med 10 siffror \n");
        }
      }
    }
  }
}
