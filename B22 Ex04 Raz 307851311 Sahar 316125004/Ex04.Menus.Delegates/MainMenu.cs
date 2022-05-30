using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IMenuItem
    {
        private string m_Title;
        private readonly List<IMenuItem> r_MenuItemList;


        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            this.r_MenuItemList = new List<IMenuItem>();
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public void AddMenuItem(IMenuItem i_MenuItem)
        {
            r_MenuItemList.Add(i_MenuItem);
        }

        public void RemoveMenuItem(IMenuItem i_MenuItem)
        {
            r_MenuItemList.Remove(i_MenuItem);
        }

        public void Choose()
        {
            Show();
        }

        public void Show()
        {
            string seperator = new string('=', Title.Length);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(Title);
                Console.WriteLine(seperator);
                printOptions();
                int numberOfOptions = r_MenuItemList.Count;
                Console.WriteLine(string.Format("Enter your request: (1 to {0} or press '0' to {1}).", numberOfOptions, ExitOrBack()));
                int userInput = getValidateInput(numberOfOptions);
                Console.Clear();

                if (userInput == 0)
                {
                    exit = true;
                }
                else
                {
                    r_MenuItemList.ElementAt(userInput - 1).Choose();
                }
            }
        }

        private void printOptions()
        {
            int index = 1;
            StringBuilder options = new StringBuilder();

            foreach (IMenuItem menuItem in r_MenuItemList)
            {
                options.AppendLine(String.Format("{0} -> {1}", index, menuItem.Title));
                index++;
            }

            options.AppendLine(ZeroOption());
            Console.WriteLine(options);
        }

        public virtual string ZeroOption()
        {
            return "0 -> Exit";
        }

        public virtual string ExitOrBack()
        {
            return "Exit";
        }

        private int getValidateInput(int i_NumberOfOptions)
        {
            string userInput = Console.ReadLine();
            int number;

            while (!int.TryParse(userInput, out number) || number > i_NumberOfOptions || number < 0)
            {
                Console.WriteLine(string.Format("Please choose integer between 0 to {0}", i_NumberOfOptions));
                userInput = Console.ReadLine();
            }

            return number;
        }
    }
}
