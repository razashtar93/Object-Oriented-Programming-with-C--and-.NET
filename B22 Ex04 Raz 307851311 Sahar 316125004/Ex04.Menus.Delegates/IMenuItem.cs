using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public interface IMenuItem
    {
        string Title
        {
            get;
            set;
        }

        void Choose();
    }
}
