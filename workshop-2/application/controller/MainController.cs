using System;

namespace application
{
  class MainController
  {
    private MainView _mv;
    private Members _members;
    private Storage _storage;

    public MainController()
    {
      _storage = new Storage();
      _members = new Members(_storage);
      _mv = new MainView();

    }
    public void run()
    {
      int choice = 0;

      try
      {
        choice = _mv.showMenu();
      }
      catch (Exception e)
      {
        _mv.printMessage(e.Message);
      }

      try
      {
        if (choice == 1)
        {
          // Add member
          handleAddingMember();
          _mv.printMessage("Successfully added a new member");

        }
        else if (choice == 2)
        {
          // View all members
          int listToShow = tryToViewMembers();
          _mv.render(getMemberList(listToShow));
        }
        else if (choice == 3)
        {
          // Remove a member
          handleRemovingMembers();
        }
        else if (choice == 4)
        {
          // Edit a member
          handleEditMember();
          _mv.printMessage("The member has been edited");
        }
        else if (choice == 5)
        {
          // Search a member
          Name name = getName();
          searchForMember(name.Username);
        }
        else if (choice == 6)
        {
          // Add a boat
          shouldAddBoat();
          _mv.printMessage("Successfully added boat");
        }
        else if (choice == 7)
        {
          // Remove a boat
          handleRemovingBoats();
        }
        else if (choice == 8)
        {
          // Change boat details
          handleEditBoat();

        }
        else if (choice == 9)
        {
          // Save and Exit
          _storage.saveToJson(_members.MemberList);
          Environment.Exit(0);
        }
      }
      catch (Exception e)
      {
        _mv.printMessage(e.Message);
      }

      run();
    }

    public void handleAddingMember()
    {
      Name newName = getName();
      PersonalIdentification newPin = getPin();
      _members.addMember(new Member(newName, newPin));
    }

    public int tryToViewMembers()
    {
      while (true)
      {
        try
        {
          int selection = _mv.renderMemberListType();
          return validateMenuChoice(selection, 1, 2); // Validate that user submits 1 or 2
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }

      }
    }

    public string getMemberList(int listToShow)
    {
      if (listToShow == 1)
      {
        return _mv.getCompactMemberList(_members.MemberList);
      }
      else
      {
        return _mv.getVerboseMemberList(_members.MemberList);
      }
    }

    public int validateMemberId()
    {
      while (true)
      {
        try
        {
          int answer = _mv.getMemberById();
          bool memberExists = _members.memberExistsById(answer);
          if (memberExists)
          {
            return answer;
          }
          else
          {
            throw new IndexOutOfRangeException("Member not found");
          }
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }
      }
    }

    public void handleEditMember()
    {
      if (_members.listHasMembers())
      {
        _mv.render(_mv.getCompactMemberList(_members.MemberList));

        int id = validateMemberId();
        Member member = _members.getMemberById(id);
        member.Name = getName();
        member.Pin = getPin();
      }
    }

    public void handleRemovingMembers()
    {
      if (_members.listHasMembers())
      {
        _mv.render(_mv.getCompactMemberList(_members.MemberList));

        int id = validateMemberId();
        _members.deleteMember(id);
        _mv.printMessage("Successfully removed member");
      }
      else
      {
        _mv.printMessage("No users found");
      }
    }

    public void handleRemovingBoats()
    {
      if (_members.listHasMembers())
      {
        _mv.render(_mv.getCompactMemberList(_members.MemberList));

        int id = validateMemberId();
        deleteBoat(id);
        _mv.printMessage("Successfully removed boat");
      }
      else
      {
        _mv.printMessage("No users found");
      }
    }

    public void handleEditBoat()
    {
      if (_members.listHasMembers())
      {
        _mv.render(_mv.getCompactMemberList(_members.MemberList));
        _mv.printMessage("Choose the member which boat(s) you want to edit");

        int id = validateMemberId();
        changeBoatDetails(id);
        _mv.printMessage("Boat successfully changed");
      }
      else
      {
        _mv.printMessage("No users found");
      }
    }

    public Name getName()
    {
      while (true)
      {
        try
        {

          string name = _mv.enterName();
          if (name.Length >= 3 && name.Length <= 15)
          {
            Name newName = new Name(name);
            return newName;
          }
          else
          {
            throw new ApplicationException("Enter a name between 3 and 15 letters");
          }

        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }
      }
    }

    public void searchForMember(string name)
    {
      if (_members.memberExistsByName(name))
      {
        Member member = _members.getMemberByName(name);
        _mv.render(_mv.showMemberProfile(member));
      }
      else
      {
        _mv.printMessage("Member not found.");
      }
    }

    public void changeBoatDetails(int id)
    {
      Member m = _members.getMemberById(id);
      _mv.render(_mv.showMembersBoats(m.Boats));

      int boatId = validateBoatId(m);
      Boat boat = m.getBoatById(boatId);
      _mv.render(_mv.showBoatTypes());

      int type = validateBoatType();
      double length = validateBoatLength();
      boat.Length = length;
      boat.Type = (BoatTypes)type;
    }

    public void shouldAddBoat()
    {
      try
      {
        int number = listOrName();
        int memberId = getMemberId(number);
        _mv.render(_mv.showBoatTypes());
        int type = validateBoatType();
        double length = validateBoatLength();

        Boat boat = new Boat((BoatTypes)type, length, memberId);
        Member m = _members.getMemberById(memberId);
        m.addBoat(boat);
        _mv.render(_mv.showBoatInfo(boat));
      }
      catch (Exception e)
      {
        _mv.printMessage(e.Message);
      }
    }

    public int getMemberId(int number)
    {

      if (number == 1)
      {
        _mv.render(_mv.getCompactMemberList(_members.MemberList));
        return validateMemberId();
      }
      else
      {
        return getMemberName();
      }
    }

    public int getMemberName()
    {
      while (true)
      {
        try
        {
          Name name = getName();
          if (_members.memberExistsByName(name.Username))
          {
            Member member = _members.getMemberByName(name.Username);
            return member.UniqueId;
          }
          else
          {
            throw new IndexOutOfRangeException("Member not found");
          }
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }
      }
    }

    public int validateBoatType()
    {

      while (true)
      {
        int type = _mv.getBoatType();
        bool exists = Enum.IsDefined(typeof(BoatTypes), type);

        if (exists)
        {
          return type;
        }
        else
        {
          _mv.printMessage("Not a valid boat type");
        }
      }
    }

    public double validateBoatLength()
    {
      while (true)
      {
        try
        {
          double length = _mv.askForBoatLength();
          return isBoatLengthValid(length);
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }

      }

    }

    public int listOrName()
    {
      while (true)
      {
        try
        {
          int ch = _mv.getWhichMemberToAssignABoat();
          return validateMenuChoice(ch, 1, 2);
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }
      }
    }

    public PersonalIdentification getPin()
    {
      while (true)
      {
        try
        {
          string pin = _mv.enterPin();
          if (pin.Length != 10)
          {
            throw new Exception("The personal identification number should only be 10 numbers");
          }
          else
          {
            return new PersonalIdentification(pin);
          }
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }
      }
    }



    public void deleteBoat(int memberId)
    {
      Member member = _members.getMemberById(memberId);
      _mv.render(_mv.getMemberBoats(member));
      int id = validateBoatId(member);
      member.removeBoat(id);
    }

    public int validateBoatId(Member member)
    {
      while (true)
      {
        try
        {
          int id = _mv.getBoatId();

          if (member.boatExists(id))
          {
            return id;
          }
          else
          {
            throw new Exception("Boat not found");
          }
        }
        catch (Exception e)
        {
          _mv.printMessage(e.Message);
        }
      }
    }

    public int validateMenuChoice(int choice, int min, int max)
    {
      if (!(choice < min || choice > max))
      {
        return choice;
      }
      else
      {
        throw new ApplicationException("Not a valid value");
      }
    }
    public double isBoatLengthValid(double length)
    {
      if (!(length < 1 || length > 20))
      {
        return length;
      }
      else
      {
        throw new ApplicationException("Not a valid length. Minimum length: 1 meter. Max length: 20 meter.");
      }
    }
  }
}
