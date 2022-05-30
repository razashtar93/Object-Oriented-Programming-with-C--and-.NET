using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    public class Tests
    {
        public void Run()
        {
            //delegateMenuTest();
            Console.Clear();
            interfaceMenuTest();
        }

        private void interfaceMenuTest()
        {
            MainMenu mainMenu = createInterfaceMenu();
            mainMenu.Show();
        }

        private MainMenu createInterfaceMenu()
        {
            MainMenu mainMenu = new MainMenu("**Interfaces Main Menu**");
            SubMenu subMenuShowDateOrTime = new SubMenu("Show Date/Time");
            SubMenu subMenuVersionAndSpaces = new SubMenu("Version and Spaces");

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
