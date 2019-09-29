using System;
using System.Collections.Generic;

namespace application
{
  class Member
  {
    private Name _name;
    private PersonalIdentification _pin;
    Random rnd = new Random();
    private int _uniqueId;

    private List<Boat> _boats = new List<Boat>();

    public Name Name { get => _name; set => _name = value; }
    public PersonalIdentification Pin { get => _pin; set => _pin = value; }
    public int UniqueId { get => _uniqueId; }

    public List<Boat> Boats { get => _boats; }

    public Member(Name name, PersonalIdentification pin)
    {
      _name = name;
      _pin = pin;
      _uniqueId = rnd.Next(10000000, 99999999);
    }

    public void addBoat(Boat boat)
    {
      _boats.Add(boat);
    }
  }
}
