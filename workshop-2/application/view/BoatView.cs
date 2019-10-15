using System;
using System.Collections.Generic;

namespace application
{
    class BoatView : MainView
    {
        private int minLength = 1;
        private int maxLength = 20;

        public string showMembersBoats(List<Boat> boats)
        {
            string output = "";

            foreach (Boat boat in boats)
            {
                output += $"\nType: {boat.Type} \nLength: {boat.Length} \nID: {boat.UniqueId}\n";
            }
            return output;
        }
        public AssignBoatMenu getWhichMemberToAssignABoat()
        {
            while (true)
            {
                Console.WriteLine("1. Select member from the member list");
                Console.WriteLine("2. Search for member");

                int answer = tryParseConsole();

                if (answer <= 2 && answer >= 1)
                {
                    return (AssignBoatMenu)answer;
                }
            }
        }

        public int getBoatType()
        {
            while (true)
            {
                Console.Write("Choose boat type: ");
                int answer = tryParseConsole();
                bool exists = Enum.IsDefined(typeof(BoatTypes), answer);

                if (exists)
                {
                    return answer;
                }
                else
                {
                    printMessage("Not a valid boat type");
                }
            }
        }

        public double askForBoatLength()
        {
            while (true)
            {
                Console.Write($"Enter boat length in meter (max {maxLength}): ");
                double answer = double.Parse(Console.ReadLine());

                if (answer >= minLength && answer <= maxLength)
                {
                    return answer;
                }
                else
                {
                    printMessage($"Not a valid length. Minimum length: {minLength} meter. Max length: {maxLength} meter.");
                }
            }
        }

        public int getBoatId(Member member)
        {
            while (true)
            {
                Console.Write("Enter ID of boat: ");
                int answer = tryParseConsole();

                if (member.boatExists(answer))
                {
                    return answer;
                }
                else
                {
                    printMessage("Boat not found");
                }
            }
        }

        public string showBoatInfo(Boat boat)
        {
            string boatInfo = $"Type: {boat.Type} Length: {boat.Length} ID: {boat.UniqueId} Owner: {boat.OwnerId}";
            return boatInfo;
        }

        public string showBoatTypes()
        {
            string types = "";
            foreach (BoatTypes type in Enum.GetValues(typeof(BoatTypes)))
            {
                types += $"\n {(int)type}. {type}";
            }
            return types;
        }

        public void printNoBoatsFound()
        {
            Console.WriteLine("No boats found");
        }

        public void printAddedBoat()
        {
            Console.WriteLine("Successfully added boat");
        }

        public void printRemovedBoat()
        {
            Console.WriteLine("Successfully removed boat");
        }

        public void printChooseMembersBoat()
        {
            Console.WriteLine("Choose the member which boat(s) you want to edit");
        }

        public void printChangedBoat()
        {
            Console.WriteLine("Boat successfully changed");
        }
    }
}