using System;

namespace application
{
  public enum BoatTypes
  {
    Sailboat = 1, Motorsailer, Kayak, Other
  }

  class BoatType
  {
    public string showBoatTypes()
    {
      string types = "";
      foreach (var type in Enum.GetValues(typeof(BoatTypes)))
      {
        types += $"\n {(int)type}. {type}";

      }
      return types;
    }
  }
}