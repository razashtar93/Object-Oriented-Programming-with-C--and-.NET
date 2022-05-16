using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly String r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;


        public Wheel(String i_ManufactorName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufactorName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public String ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public void AirToAdd(float i_AirToAdd)
        {
            // if i_AirToAdd + m_CurrentAirPressure <= r_MaxAirPressure then 
            //    m_CurrentAirPressure = m_CurrentAirPressure + i_AirToAdd     else throw exception??   
        }

    }
}
