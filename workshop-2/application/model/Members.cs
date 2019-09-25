using System;
using System.Collections.Generic;

namespace application
{
  class Members
  {
    private List<Member> memberList = new List<Member>();

    public void addMember(Member member)
    {
      memberList.Add(member);
    }

    public string getVerboseList()
    {
      string output = "";
      foreach (var member in memberList)
      {
        output += $"Name: {member.Name.Username} Personal number: {member.Pin} Member ID: {member.UniqueId} Boats: ";
      }
      return output;
    }

    public string getCompactList()
    {
      string output = "";

      if (memberList.Count == 0)
      {
        throw new ApplicationException("No members to show");
      }
      else
      {
        foreach (var member in memberList)
        {
          output += $"Name: {member.Name.Username} Member ID: {member.UniqueId} Boats: ";
        }
      }
      return output;
    }
  }
}
