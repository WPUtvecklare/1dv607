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
      else if (choice == 2)
      {
        int listToShow = vm.renderMemberListSelection();
        vm.displayMemberList(listToShow);
      }
      else if (choice == 3)
      {
        int memberId = vm.askWhichMemberToRemove();
        vm.removeMember(memberId);
      }
      else if (choice == 4)
      {
        int memberId = vm.askWhichMemberToEdit();
        vm.changeMemberDetails(memberId);
      }
      else if (choice == 5)
      {
        // string memberName = mv.enterName();
        Member member = vm.findMember();
        vm.showMember(member);
      }

      run();
    }
  }
}
