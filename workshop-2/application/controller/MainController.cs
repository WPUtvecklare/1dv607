using System;

namespace application
{
    class MainController
    {
        private MainView _mv;
        private BoatView _bv;
        private MemberView _memberView;
        private Members _members;
        private Storage _storage;

        public MainController()
        {
            _storage = new Storage();
            _members = new Members(_storage);
            _mv = new MainView();
            _bv = new BoatView();
            _memberView = new MemberView();

        }
        public void run()
        {
            MainMenu choice = 0;
            choice = _mv.showMenu();

            try
            {
                if (choice == MainMenu.AddMember)
                {
                    // Add member
                    handleAddingMember();
                    _memberView.printAddedNewMember();
                }
                else if (choice == MainMenu.ViewMembers)
                {
                    // View all members
                    MemberListTypes list = _memberView.renderMemberListType();
                    _mv.render(getMemberList(list));
                }
                else if (choice == MainMenu.RemoveMember)
                {
                    // Remove a member
                    handleRemovingMembers();
                }
                else if (choice == MainMenu.ChangeMember)
                {
                    // Edit a member
                    handleEditMember();
                    _memberView.printMemberHasBeenEdited();
                }
                else if (choice == MainMenu.SearchMember)
                {
                    // Search a member
                    searchForMember();
                }
                else if (choice == MainMenu.AddBoat)
                {
                    // Add a boat
                    shouldAddBoat();
                    _bv.printAddedBoat();
                }
                else if (choice == MainMenu.RemoveBoat)
                {
                    // Remove a boat
                    handleRemovingBoats();
                }
                else if (choice == MainMenu.ChangeBoat)
                {
                    // Change boat details
                    handleEditBoat();
                }
                else if (choice == MainMenu.SaveExit)
                {
                    // Save and Exit
                    _storage.saveToJson(_members.MemberList);
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                _mv.printMessage(e.Message);
            }

            run();
        }

        public void handleAddingMember()
        {
            string newName = _memberView.enterName();
            string newPin = _memberView.enterPin();

            Name name = new Name(newName);
            PersonalIdentification pin = new PersonalIdentification(newPin);

            _members.addMember(new Member(name, pin));
        }

        public string getMemberList(MemberListTypes listToShow)
        {
            return listToShow == MemberListTypes.Compact
            ? _memberView.getCompactMemberList(_members.MemberList)
            : _memberView.getVerboseMemberList(_members.MemberList);
        }
        public void handleEditMember()
        {
            if (_members.listHasMembers())
            {
                _mv.render(_memberView.getCompactMemberList(_members.MemberList));

                int id = _memberView.getMemberById(_members);

                Member member = _members.getMemberById(id);
                member.Name = new Name(_memberView.enterName());
                member.Pin = new PersonalIdentification(_memberView.enterPin());
            }
        }

        public void handleRemovingMembers()
        {
            if (_members.listHasMembers())
            {
                _mv.render(_memberView.getCompactMemberList(_members.MemberList));

                int id = _memberView.getMemberById(_members);
                _members.deleteMember(id);
                _memberView.printRemovedMember();
            }
            else
            {
                _memberView.printNoUsersFound();
            }
        }

        public void handleRemovingBoats()
        {
            if (_members.listHasMembers())
            {
                _mv.render(_memberView.getCompactMemberList(_members.MemberList));

                int id = _memberView.getMemberById(_members);

                Member m = _members.getMemberById(id);

                if (m.Boats.Count >= 1)
                {
                    deleteBoat(id);
                    _bv.printRemovedBoat();
                }
                else
                {
                    _bv.printNoBoatsFound();
                }

            }
            else
            {
                _memberView.printNoUsersFound();
            }
        }

        public void handleEditBoat()
        {
            if (_members.listHasMembers())
            {
                _mv.render(_memberView.getCompactMemberList(_members.MemberList));
                _bv.printChooseMembersBoat();

                int id = _memberView.getMemberById(_members);

                Member m = _members.getMemberById(id);

                if (m.Boats.Count >= 1)
                {
                    changeBoatDetails(id);
                    _bv.printChangedBoat();

                }
                else
                {
                    _bv.printNoBoatsFound();
                }
            }
            else
            {
                _memberView.printNoUsersFound();
            }
        }

        public void searchForMember()
        {
            string nameToSearch = _memberView.enterName();
            Name name = new Name(nameToSearch);

            if (_members.memberExistsByName(name.Username))
            {
                Member member = _members.getMemberByName(name.Username);
                _mv.render(_memberView.showMemberProfile(member));
            }
            else
            {
                _memberView.printMemberNotFound();
                searchForMember();
            }
        }

        public void changeBoatDetails(int id)
        {
            Member m = _members.getMemberById(id);
            _mv.render(_bv.showMembersBoats(m.Boats));

            int boatId = _bv.getBoatId(m);
            Boat boat = m.getBoatById(boatId);
            _mv.render(_bv.showBoatTypes());

            int type = _bv.getBoatType();
            double length = _bv.askForBoatLength();
            boat.Length = length;
            boat.Type = (BoatTypes)type;
        }

        public void shouldAddBoat()
        {
            AssignBoatMenu choice = _bv.getWhichMemberToAssignABoat();
            int memberId = 0;

            if (choice == AssignBoatMenu.Select)
            {
                _mv.render(_memberView.getCompactMemberList(_members.MemberList));
                memberId = _memberView.getMemberById(_members);
            }
            else if (choice == AssignBoatMenu.Search)
            {
                memberId = getMemberName();
            }

            _mv.render(_bv.showBoatTypes());
            int type = _bv.getBoatType();
            double length = _bv.askForBoatLength();

            Boat boat = new Boat((BoatTypes)type, length, memberId);
            Member m = _members.getMemberById(memberId);
            m.addBoat(boat);
            _mv.render(_bv.showBoatInfo(boat));
        }

        public int getMemberName()
        {
            Name name = new Name(_memberView.enterName());
            int uniqueId = 0;

            if (_members.memberExistsByName(name.Username))
            {
                Member member = _members.getMemberByName(name.Username);
                uniqueId = member.UniqueId;
                return uniqueId;
            }
            else
            {
                _memberView.printMemberNotFound();
                getMemberName();
            }
            return uniqueId;
        }

        public void deleteBoat(int memberId)
        {
            Member member = _members.getMemberById(memberId);
            _mv.render(_memberView.getMemberBoats(member));
            int id = _bv.getBoatId(member);
            member.removeBoat(id);
        }
    }
}
