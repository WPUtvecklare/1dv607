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

    public bool isValid()
    {
      if (_pin.Length == 10)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
