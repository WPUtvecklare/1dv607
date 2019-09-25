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

    public override string ToString()
    {
      string output = "";
      foreach (var member in memberList)
      {
        output += member.ToString();
      }
      return output;
    }
  }
}
