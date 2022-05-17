using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Owner //Done.
    {
        private string m_Name;
        private string m_PhoneNumber;

        public Owner(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }



        public override string ToString()
        {
            return String.Format("Owner: Name - {0} , Phone Number - {1}", m_Name, m_PhoneNumber);
        }
    }
}
