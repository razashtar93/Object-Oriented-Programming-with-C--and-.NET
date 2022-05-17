using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.VehicleGenerator;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_RefrigeratedContents;
        private float m_CargoVolume;


        public Truck(string i_ModelName, string i_LicencePlate, Wheel[] i_Wheels, PowerSource i_PowerSource, eVehicleType i_VehicleType,
           bool i_RefrigeratedContents, float i_CargoVolume) : base(i_ModelName, i_LicencePlate, i_Wheels, i_PowerSource, i_VehicleType)
        {
            m_RefrigeratedContents = i_RefrigeratedContents;
            m_CargoVolume = i_CargoVolume;
        }

        public bool RefrigeratedContents
        {
            get { return m_RefrigeratedContents; }
            set { m_RefrigeratedContents = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.AppendLine(String.Format("m_Refrigerated Contents: {0}", m_RefrigeratedContents));
            output.AppendLine(String.Format("Cargo volume: {0}", m_CargoVolume));

            return output.ToString();
        }

    }
}
