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
        throw new ApplicationException("Ange ett namn mellan 3 och 15 bokstäver");
      }
      return newName;
    }

    public PersonalIdentification validatePin()
    {
      string pin = MainView.enterPin();
      PersonalIdentification newPin = new PersonalIdentification(pin);

      if (!newPin.isValid())
      {
        throw new ApplicationException("Ange ett personnummer med 10 siffror");
      }
      return newPin;
    }

    public int showMenu()
    {
      int choice;
      while (true)
      {
        choice = MainView.showMenu();
        if (!(choice < 1 || choice > 7))
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
    }

    public int renderMemberListSelection()
    {
      int choice;
      while (true)
      {
        try
        {
          choice = MainView.renderMemberListType();
          if (!(choice < 1 || choice > 2))
          {
            return choice;
          }
          else
          {
            throw new ApplicationException("Inte ett giltigt värde");
          }
        }
        catch (Exception e)
        {
          MainView.printMessage(e.Message);
        }
      }
    }

    public void displayMemberList(int choice)
    {
      try
      {
        if (choice == 1)
        {

          MainView.render(MainView.getCompactMemberList(members.MemberList));
        }
        else
        {
          MainView.render(MainView.getVerboseMemberList(members.MemberList));
        }
      }
      catch (Exception e)
      {
        MainView.printMessage(e.Message);
      }
    }

    public int askForMemberId()
    {
      int answer = 0;

      if (listHasMembers())
      {
        MainView.render(MainView.getCompactMemberList(members.MemberList));
        while (true)
        {
          try
          {
            answer = MainView.getMemberById();
            return answer;
          }
          catch (Exception e)
          {
            MainView.printMessage(e.Message);
          }
        }
      }
      else
      {
        return answer;
      }
    }

    public bool listHasMembers()
    {
      try
      {
        MainView.getCompactMemberList(members.MemberList);
        return true;
      }
      catch (Exception e)
      {
        MainView.printMessage(e.Message);
        return false;
      }
    }

    public void removeMember(int memberId)
    {
      try
      {
        if (listHasMembers())
        {
          members.deleteMember(memberId);
          MainView.printMessage("Successfully removed member with ID " + memberId);
        }
      }
      catch (Exception e)
      {
        MainView.printMessage(e.Message);
      }
    }

    public int askWhichMemberToEdit()
    {
      int answer = 0;

      if (listHasMembers())
      {
        MainView.render(MainView.getCompactMemberList(members.MemberList));
        while (true)
        {
          try
          {
            answer = MainView.getMemberToEdit();
            return answer;
          }
          catch (Exception e)
          {
            MainView.printMessage(e.Message);
          }
        }
      }
      else
      {
        return answer;
      }
    }

    public void changeMemberDetails(int memberId)
    {
      try
      {
        if (listHasMembers())
        {
          Member memberToEdit = members.memberExists(memberId);
          MainView.render(MainView.showMember(memberToEdit));

          Name newName = getName();
          PersonalIdentification newPin = getPin();
          memberToEdit.Name = newName;
          memberToEdit.Pin = newPin;

          MainView.printMessage($"Member has successfully been edited to {newName.Username} and PIN: {newPin.Pin} ");
        }
      }
      catch (Exception e)
      {
        MainView.printMessage(e.Message);
      }
    }

    public Member findMember()
    {
      string name;
      Member member;
      while (true)
      {
        try
        {
          name = MainView.enterName();
          member = members.findMemberByName(name);
          return member;
        }
        catch (Exception e)
        {
          MainView.printMessage(e.Message);
        }
      }
    }

    public void showMember(Member member)
    {
      MainView.render(MainView.showMemberProfile(member));
    }

    public int selectView()
    {
      int choice;
      while (true)
      {
        choice = MainView.getWhichMemberToAssignABoat();
        if (!(choice < 1 || choice > 2))
        {
          return choice;
        }
        else
        {
          throw new ApplicationException("Inte ett giltigt värde");
        }
      }
    }

    public int decideView(int number)
    {
      try
      {
        if (number == 1)
        {
          MainView.render(MainView.getCompactMemberList(members.MemberList));
          int id = askForMemberId();
          return id;
        }
        else if (number == 2)
        {
          Member member = findMember();
          return member.UniqueId;
        }

      }
      catch (Exception e)
      {
        MainView.printMessage(e.Message);
      }
      return number;
    }

    public int decideBoatType()
    {
      MainView.render(MainView.showBoatTypes());
      int type = MainView.getBoatType();
      return type;
    }

    public double getBoatLength()
    {
      double length = MainView.askForBoatLength();
      return length;
    }

    public Boat addBoat(int id, BoatTypes type, double length)
    {
      return new Boat(type, length, id);
    }
  }
}