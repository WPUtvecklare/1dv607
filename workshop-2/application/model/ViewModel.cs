using System;

namespace application
{
  class ViewModel
  {
    private MainView MainView = new MainView();
    private Members members = new Members();
    public Name validateUsername()
    {
      string name = MainView.enterName();
      Name newName = new Name(name);

      if (!newName.isValid())
      {
        throw new ApplicationException("\n Ange ett namn mellan 3 och 15 bokstäver \n");
      }
      return newName;
    }

    public PersonalIdentification validatePin()
    {
      string pin = MainView.enterPin();
      PersonalIdentification newPin = new PersonalIdentification(pin);

      if (!newPin.isValid())
      {
        throw new ApplicationException("\n Ange ett personnummer med 10 siffror \n");
      }
      return newPin;
    }

    public int showMenu()
    {
      int choice;
      while (true)
      {
        choice = MainView.showMenu();
        if (!(choice < 1 || choice > 4))
        {
          return choice;
        }
        else
        {
          throw new ApplicationException("Inte ett giltigt värde");
        }
      }
    }

    public Member addMember(Name name, PersonalIdentification pin)
    {
      return new Member(name, pin);
    }

    public PersonalIdentification getPin()
    {
      while (true)
      {
        try
        {
          return validatePin();
        }
        catch (Exception e)
        {
          MainView.printMessage(e.Message);
        }
      }
    }

    public Name getName()
    {
      while (true)
      {
        try
        {
          return validateUsername();
        }
        catch (Exception e)
        {
          MainView.printMessage(e.Message);
        }
      }
    }

    public void tryToAddMember()
    {
      Name name = getName();
      PersonalIdentification pin = getPin();
      Member member = addMember(name, pin);
      members.addMember(member);
      MainView.printMessage("Successfully added a new member");
      System.Console.WriteLine(members.ToString());
    }
  }
}