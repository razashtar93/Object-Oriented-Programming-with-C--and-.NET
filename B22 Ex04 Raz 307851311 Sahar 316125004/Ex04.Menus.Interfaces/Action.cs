﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Action : IMenuItem
    {
        private string m_Title;
        private readonly List<IActionListener> r_ActionList;

        public Action(string i_Title)
        {
            m_Title = i_Title;
            this.r_ActionList = new List<IActionListener>();
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public void AddActionItem(IActionListener i_ActionItem)
        {
            r_ActionList.Add(i_ActionItem);
        }

        public void RemoveActionItem(IActionListener i_ActionItem)
        {
            r_ActionList.Remove(i_ActionItem);
        }

        public void Choose()
        {
            Console.Clear();

            foreach (IActionListener actionItem in r_ActionList)
            {
                actionItem.Run();
            }
        }
    }
}
