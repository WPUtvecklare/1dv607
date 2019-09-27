using System;
using System.Collections.Generic;

namespace application
{
  class Members
  {
    private List<Member> memberList = new List<Member>();

    public List<Member> MemberList { get => memberList; }

    public void addMember(Member member)
    {
      memberList.Add(member);
    }

    public void deleteMember(int memberId)
    {
      Member member = memberExists(memberId);
      memberList.RemoveAll(m => m.UniqueId == memberId);
    }

    public Member memberExists(int memberId)
    {
      Member member = memberList.Find(m => m.UniqueId == memberId);

      if (member == null)
      {
        throw new Exception("Member not found");
      }
      return member;
    }

    public Member findMemberByName(string name)
    {
      Member member = memberList.Find(m => m.Name.Username == name);
      if (member == null)
      {
        throw new Exception("Member not found");
      }
      return member;
    }
  }
}
