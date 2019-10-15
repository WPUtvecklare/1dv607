using System;

namespace application
{
    class Program
    {
        static void Main()
        {
            Storage _storage = new Storage();

            Members _members = new Members(_storage);
            MainView _mv = new MainView();
            BoatView _bv = new BoatView();
            MemberView _memberView = new MemberView();

            MainController mc = new MainController(_members, _mv, _bv, _memberView);
            mc.run();
        }
    }
}
