using System;

namespace application
{
  class Boat
  {
    private Enum _type;
    private string _length;
    public Enum Type { get => _type; set => _type = value; }
    public string Length { get => _length; set => _length = value; }

    public Boat(Enum type, string length)
    {
      _type = type;
      _length = length;
    }
  }
}
