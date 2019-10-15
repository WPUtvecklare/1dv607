using System;

namespace application
{
    class Boat
    {
        private BoatTypes _type;
        private double _length;
        private int _ownerId;
        public BoatTypes Type { get => _type; set => _type = value; }
        public double Length { get => _length; set => _length = value; }
        public int OwnerId { get => _ownerId; set => _ownerId = value; }
        public int UniqueId { get => _uniqueId; set => _uniqueId = value; }

        Random rnd = new Random();
        private int _uniqueId;

        public Boat(BoatTypes type, double length, int ownerId)
        {
            _type = type;
            _length = length;
            _uniqueId = rnd.Next(10000000, 99999999);
            _ownerId = ownerId;
        }
    }
}
