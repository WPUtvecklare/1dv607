using System;
using System.Collections.Generic;

namespace application
{
  class Members
  {
    private List<Member> _memberList = new List<Member>();

    public List<Member> MemberList { get => _memberList; }

    public void addMember(Member member)
    {
      _memberList.Add(member);
    }

    public void deleteMember(int memberId)
    {
      _memberList.RemoveAll(m => m.UniqueId == memberId);
    }

    public bool memberExistsById(int memberId)
    {
      Member member = _memberList.Find(m => m.UniqueId == memberId);

      if (member == null)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public bool memberExistsByName(string name)
    {
      Member member = _memberList.Find(m => m.Name.Username == name);
      if (member == null)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public Member getMemberByName(string name)
    {
      Member member = _memberList.Find(m => m.Name.Username == name);
      return member;
    }

    public Member getMemberById(int id)
    {
      Member member = _memberList.Find(m => m.UniqueId == id);
      return member;
    }

    public bool listHasMembers()
    {
      if (_memberList.Count == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }
  }
}
