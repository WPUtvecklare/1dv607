using System;

namespace application
{
  class MainController
  {
    MainView mv = new MainView();
    // Members members = new Members();
    public void run()
    {
      int menuchoice = mv.showMenu();

      if (menuchoice == 1)
      {
        string name = mv.renderAddNewMember();
        int pid = mv.personalID();
      }
    }
  }
}
