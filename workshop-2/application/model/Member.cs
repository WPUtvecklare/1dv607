using System;

namespace application
{
  class Member
  {
    private Name _name;
    private PersonalIdentification _pin;
    Random rnd = new Random();
    private int _uniqueId;

    public Member(Name name, PersonalIdentification pin)
    {
      _name = name;
      _pin = pin;
      _uniqueId = rnd.Next(10000000, 99999999);
    }

    public override string ToString()
    {
      return $"Name: {_name.Username} \nPIN: {_pin.Pin}\n ID: {_uniqueId} ";
    }
  }
}
