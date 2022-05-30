using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Tests
    {
        public void Run()
        {
            //runDelegateMenu();
            Console.Clear();
            runInterfaceMenu();
        }

        private void runInterfaceMenu()
        {
            Interfaces.MainMenu mainMenu = createInterfaceMenu();
            mainMenu.Show();
        }

        private Interfaces.MainMenu createInterfaceMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("**Interfaces Main Menu**");
            Interfaces.SubMenu subMenuShowDateOrTime = new Interfaces.SubMenu("Show Date/Time");
            Interfaces.SubMenu subMenuVersionAndSpaces = new Interfaces.SubMenu("Version and Spaces");

            mainMenu.AddMenuItem(subMenuShowDateOrTime);
            mainMenu.AddMenuItem(subMenuVersionAndSpaces);

            //item 1
            Interfaces.Action ShowTime = new Interfaces.Action("Show Time");
            ShowTime.AddActionItem(new ShowTime());

            Interfaces.Action ShowDate = new Interfaces.Action("Show Date");
            ShowDate.AddActionItem(new ShowDate());

            subMenuShowDateOrTime.AddMenuItem(ShowTime);
            subMenuShowDateOrTime.AddMenuItem(ShowDate);

            //item 2
            Interfaces.Action CountSpacesAction = new Interfaces.Action("Count Spaces");
            CountSpacesAction.AddActionItem(new CountSpaces());

            Interfaces.Action ShowVersion = new Interfaces.Action("Show Version");
            ShowVersion.AddActionItem(new ShowVersion());

            subMenuVersionAndSpaces.AddMenuItem(CountSpacesAction);
            subMenuVersionAndSpaces.AddMenuItem(ShowVersion);

            return mainMenu;
        }
    }
}
