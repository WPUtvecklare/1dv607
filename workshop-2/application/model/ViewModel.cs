using System;

namespace application
{
  class ViewModel
  {
    public Name validateUsername(Name newName)
    {
      if (!newName.isValid())
      {
        throw new ApplicationException("Enter a name between 3 and 15 letters");
      }
      return newName;
    }

    public PersonalIdentification validatePin(PersonalIdentification newPin)
    {
      if (!newPin.isValid())
      {
        throw new ApplicationException("The personal identification number should only be 10 numbers");
      }
      return newPin;
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