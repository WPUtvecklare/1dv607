using System;

namespace application
{
    class Name
    {
        private string _name;
        public string Username { get => _name; set => _name = value; }

        public Name(string name)
        {
            _name = name;
        }
    }
}
