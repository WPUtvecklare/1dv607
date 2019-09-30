namespace application
{
  class Name
  {
    private string _name;
    public string Username { get => _name; set => _name = value; }

    public Name(string name)
    {
      _name = name;
    }

    public bool isValid()
    {
      if (_name.Length >= 3 && _name.Length <= 15)
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
