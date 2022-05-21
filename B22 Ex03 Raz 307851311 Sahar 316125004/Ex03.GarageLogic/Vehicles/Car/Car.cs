using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.VehicleGenerator;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_ModelName, string i_LicencePlate, Wheel[] i_Wheels,
            PowerSource i_PowerSource, eVehicleType i_VehicleType)
            : base(i_ModelName, i_LicencePlate, i_Wheels, i_PowerSource, i_VehicleType)
        {

        }

        public Car(string i_ModelName, string i_LicencePlate, Wheel[] i_Wheels,
            PowerSource i_PowerSource, eVehicleType i_VehicleType, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
            : base(i_ModelName, i_LicencePlate, i_Wheels, i_PowerSource, i_VehicleType)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public eColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());

            output.AppendLine(String.Format("Number of doors : {0}", m_NumberOfDoors));
            output.AppendLine(String.Format("Car color: {0}", m_CarColor));

            return output.ToString();
        }
    }
}
