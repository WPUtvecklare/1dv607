using System;

namespace application
{
  class Boat
  {
    private BoatTypes _type;
    private double _length;
    private int _ownerId;
    public BoatTypes Type { get => _type; set => _type = value; }
    public double Length { get => _length; set => _length = value; }

    Random rnd = new Random();
    private int _uniqueId;

    public Boat(BoatTypes type, double length, int ownerId)
    {
      _type = type;
      _length = length;
      _uniqueId = rnd.Next(10000000, 99999999);
      _ownerId = ownerId;
    }

    public string showBoatInfo()
    {
      return $"Type: {_type} Length: {_length} ID: {_uniqueId} Owner: {_ownerId} ";
    }
  }
}
