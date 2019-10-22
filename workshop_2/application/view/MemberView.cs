using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace application
{
    class MemberView : MainView
    {
        private int minLength = 3;
        private int maxLength = 15;

        public string enterName()
        {
            while (true)
            {
                Console.Write("Enter name: ");
                string newName = Console.ReadLine();

                if (newName.Length >= minLength && newName.Length <= maxLength)
                {
                    return newName;
                }
                else
                {
                    printMessage("Enter a name between 3 and 15 letters");
                }
            }
        }

        public string enterPin()
        {
            while (true)
            {
                Console.Write("Enter personal number (10 numbers): ");
                string pin = Console.ReadLine();

                if (pin.Length == 10)
                {
                    return pin;
                }
                else
                {
                    printMessage("The personal identification number should only be 10 numbers");
                }
            }
        }

        public MemberListTypes renderMemberListType()
        {
            while (true)
            {
                int number = 0;
                Console.WriteLine("1. Compact List");
                Console.WriteLine("2. Verbose List");

                try
                {
                    number = tryParseConsole();
                }
                catch (Exception)
                {
                    printMessage("Not a valid value");
                }

                if (number <= 2 && number >= 1)
                {
                    return (MemberListTypes)number;
                }
                else
                {
                    printMessage("Enter a number between 1 and 2");
                }
            }
        }

        public int getMemberById(Members members)
        {
            while (true)
            {
                Console.Write("Enter ID: ");
                int id = tryParseConsole();

                if (members.memberExistsById(id))
                {
                    return id;
                }
                else
                {
                    printMessage("Member not found");
                }
            }
        }

        public string getVerboseMemberList(ReadOnlyCollection<Member> memberList)
        {
            string output = "";

            if (memberList.Count == 0)
            {
                throw new ApplicationException("No members to show");
            }

            foreach (Member member in memberList)
            {
                output += $"\nName: {member.getName()} Personal number: {member.getPin()} Member ID: {member.UniqueId} Boats: {getMemberBoats(member)} ";
            }
            return output;
        }

        public string getCompactMemberList(ReadOnlyCollection<Member> memberList)
        {
            string output = "";

            if (memberList.Count == 0)
            {
                throw new ApplicationException("No members to show");
            }
            else
            {
                foreach (Member member in memberList)
                {
                    output += $"\nName: {member.getName()} Member ID: {member.UniqueId} Boats: {member.Boats.Count}";
                }
                return output;
            }
        }

        public string showMemberProfile(Member member)
        {
            return $"Name: {member.getName()} Personal ID: {member.getPin()} Boats: {member.Boats.Count}";
        }

        public string showMember(Member member)
        {
            return $"Name: {member.getName()} Personal ID: {member.getPin()} ";
        }

        public string getMemberBoats(Member member)
        {
            string output = "";

            foreach (Boat boat in member.Boats)
            {
                output += $"\nType: {boat.Type} \nLength: {boat.Length} \nID: {boat.UniqueId}\n";
            }

            if (output.Length == 0)
            {
                output += "0";
            }
            return output;
        }

        public void printMemberNotFound()
        {
            Console.WriteLine("Member not found");
        }

        public void printNoUsersFound()
        {
            Console.WriteLine("No users found");
        }

        public void printAddedNewMember()
        {
            Console.WriteLine("Successfully added new member");
        }

        public void printMemberHasBeenEdited()
        {
            Console.WriteLine("Member has been edited");
        }

        public void printRemovedMember()
        {
            Console.WriteLine("Successfully removed member");
        }
    }
}