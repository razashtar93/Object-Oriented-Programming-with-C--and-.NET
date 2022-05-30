using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Tests
    {
        private Delegates.MainMenu m_DelegatesMainMenu;
        private Interfaces.MainMenu m_InterfacesMainMenu;

        public void Run()
        {
            delegateMenuTest();
            Console.Clear();
            interfaceMenuTest();
        }

        private void delegateMenuTest()
        {
            m_DelegatesMainMenu = createDelegatesMenu();
            m_DelegatesMainMenu.Show();
        }

        private void interfaceMenuTest()
        {
            m_InterfacesMainMenu = createInterfaceMenu();
            m_InterfacesMainMenu.Show();
        }

        private Delegates.MainMenu createDelegatesMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("**Delegates Main Menu**");
            Delegates.SubMenu subMenuShowDateOrTime = new Delegates.SubMenu("Show Date/Time");
            Delegates.SubMenu subMenuVersionAndSpaces = new Delegates.SubMenu("Version and Spaces");

            mainMenu.AddMenuItem(subMenuShowDateOrTime);
            mainMenu.AddMenuItem(subMenuVersionAndSpaces);

            //item 1
            Delegates.Actions ShowTime = new Delegates.Actions("Show Time");
            ShowTime.m_EventHandler += new ShowTime().Run;

            Delegates.Actions ShowDate = new Delegates.Actions("Show Date");
            ShowDate.m_EventHandler += new ShowDate().Run;

            subMenuShowDateOrTime.AddMenuItem(ShowTime);
            subMenuShowDateOrTime.AddMenuItem(ShowDate);

            //item 2
            Delegates.Actions CountSpacesAction = new Delegates.Actions("Count Spaces");
            CountSpacesAction.m_EventHandler += new CountSpaces().Run;

            Delegates.Actions ShowVersion = new Delegates.Actions("Show Version");
            ShowVersion.m_EventHandler += new ShowVersion().Run;

            subMenuVersionAndSpaces.AddMenuItem(CountSpacesAction);
            subMenuVersionAndSpaces.AddMenuItem(ShowVersion);

            return mainMenu;
        }

        private Interfaces.MainMenu createInterfaceMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("**Interfaces Main Menu**");
            Interfaces.SubMenu subMenuShowDateOrTime = new Interfaces.SubMenu("Show Date/Time");
            Interfaces.SubMenu subMenuVersionAndSpaces = new Interfaces.SubMenu("Version and Spaces");

            mainMenu.AddMenuItem(subMenuShowDateOrTime);
            mainMenu.AddMenuItem(subMenuVersionAndSpaces);

            //item 1
            Interfaces.Actions ShowTime = new Interfaces.Actions("Show Time");
            ShowTime.AddActionItem(new ShowTime());

            Interfaces.Actions ShowDate = new Interfaces.Actions("Show Date");
            ShowDate.AddActionItem(new ShowDate());

            subMenuShowDateOrTime.AddMenuItem(ShowTime);
            subMenuShowDateOrTime.AddMenuItem(ShowDate);

            //item 2
            Interfaces.Actions CountSpacesAction = new Interfaces.Actions("Count Spaces");
            CountSpacesAction.AddActionItem(new CountSpaces());

            Interfaces.Actions ShowVersion = new Interfaces.Actions("Show Version");
            ShowVersion.AddActionItem(new ShowVersion());

            subMenuVersionAndSpaces.AddMenuItem(CountSpacesAction);
            subMenuVersionAndSpaces.AddMenuItem(ShowVersion);

            return mainMenu;
        }
    }
}
