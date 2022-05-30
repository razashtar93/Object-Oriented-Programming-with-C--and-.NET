using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Actions : IMenuItem
    {
        private string m_Title;
        private readonly List<IActionExcecution> r_ActionList;

        public Actions(string i_Title)
        {
            this.m_Title = i_Title;
            this.r_ActionList = new List<IActionExcecution>();
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public void AddActionItem(IActionExcecution i_ActionItem)
        {
            r_ActionList.Add(i_ActionItem);
        }

        public void RemoveActionItem(IActionExcecution i_ActionItem)
        {
            r_ActionList.Remove(i_ActionItem);
        }

        public void Choose()
        {
            Console.Clear();

            foreach (IActionExcecution actionItem in r_ActionList)
            {
                actionItem.Run();
            }
        }
    }
}
