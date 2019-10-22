using System;
using System.Collections.Generic;

namespace application
{
    class Member
    {
        private Name _name;
        private PersonalIdentification _pin;
        Random rnd = new Random();
        private int _uniqueId;

        private List<Boat> _boats = new List<Boat>();

        public Name Name
        {
            get => _name; set
            {
                _name = value;
            }
        }
        public PersonalIdentification Pin { get => _pin; set => _pin = value; }
        public int UniqueId { get => _uniqueId; }

        public List<Boat> Boats { get => _boats; }

        public Member(Name name, PersonalIdentification pin)
        {
            _name = name;
            _pin = pin;
            _uniqueId = rnd.Next(10000000, 99999999);
        }

        public void addBoat(int type, double length, int memberId) => _boats.Add(new Boat((BoatTypes)type, length, memberId));

        public void removeBoat(int id) => _boats.RemoveAll(b => b.UniqueId == id);


        public Boat getBoatById(int id) => _boats.Find(m => m.UniqueId == id);

        public bool boatExists(int id)
        {
            Boat boat = _boats.Find(m => m.UniqueId == id);
            return boat == null ? false : true;
        }

        public void editBoat(int id, int type, double length)
        {
            Boat boat = getBoatById(id);
            boat.Length = length;
            boat.Type = (BoatTypes)type;
        }

        public List<Boat> getMemberBoats()
        {
            return Boats;
        }

        public string getName() => _name.Username;

        public string getPin() => _pin.Pin;
    }
}
