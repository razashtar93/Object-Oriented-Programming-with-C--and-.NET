using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Actions : IMenuItem
    {
        private string m_Title;
        public event Action m_EventHandler;

        public Actions(string i_Title)
        {
            this.m_Title = i_Title;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public void Choose()
        {
            Console.Clear();
            OnChoose();
        }

        protected virtual void OnChoose()
        {
            if (m_EventHandler != null)
            {
                this.m_EventHandler.Invoke();
            }
        }
    }
}
