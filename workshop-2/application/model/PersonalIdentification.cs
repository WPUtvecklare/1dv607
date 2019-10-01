using System;

namespace application
{
  class PersonalIdentification
  {
    private string _pin;
    public string Pin { get => _pin; }

    public PersonalIdentification(string pin)
    {
      _pin = pin;
    }
  }
}
