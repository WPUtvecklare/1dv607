using System;

namespace application
{
  class MainController
  {
    MainView mv = new MainView();
    ViewModel vm = new ViewModel();
    public void run()
    {
      int choice = 0;

      try
      {
        choice = vm.showMenu();
      }
      catch (Exception e)
      {
        mv.printMessage(e.Message);
      }

      if (choice == 1)
      {
        vm.tryToAddMember();
      }

      run();
    }
  }
}
