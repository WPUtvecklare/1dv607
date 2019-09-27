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
        int memberId = vm.askForMemberId();
        vm.removeMember(memberId);
      }
      else if (choice == 4)
      {
        int memberId = vm.askWhichMemberToEdit();
        vm.changeMemberDetails(memberId);
      }
      else if (choice == 5)
      {
        Member member = vm.findMember();
        vm.showMember(member);
      }
      else if (choice == 6)
      {
        int number = vm.selectView();
        int id = vm.decideView(number);
        int type = vm.decideBoatType();
        double length = vm.getBoatLength();
        Boat boat = vm.addBoat(id, (BoatTypes)type, length);
        mv.render(mv.showBoatInfo(boat));
      }

      run();
    }
  }
}
