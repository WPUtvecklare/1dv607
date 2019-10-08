using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace application
{
    class Members
    {
        private List<Member> _memberList = new List<Member>();

        public ReadOnlyCollection<Member> MemberList { get => new ReadOnlyCollection<Member>(_memberList); }

        public Members(Storage storage)
        {
            if (storage.loadUsers() != null)
            {
                _memberList = storage.loadUsers();
            }
        }
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
            return member == null ? false : true;
        }

        public bool memberExistsByName(string name)
        {
            Member member = _memberList.Find(m => m.Name.Username == name);
            return member == null ? false : true;
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

        public bool listHasMembers() => _memberList.Count == 0 ? false : true;
    }
}
