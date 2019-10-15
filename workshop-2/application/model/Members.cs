using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace application
{
    class Members
    {
        private Storage _storage;
        private List<Member> _memberList = new List<Member>();
        public ReadOnlyCollection<Member> MemberList { get => new ReadOnlyCollection<Member>(_memberList); }

        public Members(Storage storage)
        {
            _storage = storage;

            if (storage.loadUsers<Member>() != null)
            {
                _memberList = storage.loadUsers<Member>();
            }
        }
        public void addMember(string name, string pin)
        {
            Member member = new Member(new Name(name), new PersonalIdentification(pin));
            _memberList.Add(member);
        }

        public void updateMember(int id, string name, string pin)
        {
            Member member = getMemberById(id);
            member.Name = new Name(name);
            member.Pin = new PersonalIdentification(pin);
        }

        public void addBoatToMember(int id, int type, double length)
        {
            Member member = getMemberById(id);
            member.addBoat(type, length, id);
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

        public void saveMembers()
        {
            _storage.saveToJson(MemberList);
        }
    }
}
