using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MainMenu
    {
        public SubMenu(string i_Title) : base(i_Title)
        {

        }

        public override string ZeroOption()
        {
            return "0 -> Back";
        }

        public override string ExitOrBack() 
        {
            return "go Back";
        }
    }
}
