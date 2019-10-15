using System;

namespace application
{
    class MainController
    {
        private MainView _mv;
        private BoatView _bv;
        private MemberView _memberView;
        private Members _members;

        public MainController(Members members, MainView mv, BoatView bv, MemberView memberView)
        {
            _members = members;
            _mv = mv;
            _bv = bv;
            _memberView = memberView;
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
                }
                else if (choice == MainMenu.ViewMembers)
                {
                    // View all members
                    handleViewingMembers();
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
                    _members.saveMembers();
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
            string name = _memberView.enterName();
            string pin = _memberView.enterPin();
            _members.addMember(name, pin);
            _memberView.printAddedNewMember();
        }

        public void handleViewingMembers()
        {
            MemberListTypes list = _memberView.renderMemberListType();
            _mv.render(getMemberList(list));
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
                string name = _memberView.enterName();
                string pin = _memberView.enterPin();

                _members.updateMember(id, name, pin);
                _memberView.printMemberHasBeenEdited();
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

                if (m.getMemberBoats().Count >= 1)
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

                if (m.getMemberBoats().Count >= 1)
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

            if (_members.memberExistsByName(nameToSearch))
            {
                Member member = _members.getMemberByName(nameToSearch);
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
            _mv.render(_bv.showMembersBoats(m.getMemberBoats()));
            int boatId = _bv.getBoatId(m);

            _mv.render(_bv.showBoatTypes());

            int type = _bv.getBoatType();
            double length = _bv.askForBoatLength();

            m.editBoat(boatId, type, length);
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

            _members.addBoatToMember(memberId, type, length);

            _bv.printAddedBoat();
        }

        public int getMemberName()
        {
            string name = _memberView.enterName();
            int uniqueId = 0;

            if (_members.memberExistsByName(name))
            {
                Member member = _members.getMemberByName(name);
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
