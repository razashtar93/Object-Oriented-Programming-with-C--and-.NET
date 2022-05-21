using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_LicencePlate, Wheel[] i_Wheel, PowerSource i_PowerSource, VehicleGenerator.eVehicleType i_VehicleType)
            : base(i_ModelName, i_LicencePlate, i_Wheel, i_PowerSource, i_VehicleType)
        {

        }

        public Motorcycle(string i_ModelName, string i_LicencePlate, Wheel[] i_Wheel, PowerSource i_PowerSource,
            eLicenceType i_LicenceType, int i_EngineCapacity, VehicleGenerator.eVehicleType i_VehicleType)
            : base(i_ModelName, i_LicencePlate, i_Wheel, i_PowerSource, i_VehicleType)
        {
            m_LicenceType = i_LicenceType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public eLicenceType LicenceType
        {
            get { return m_LicenceType; }
            set { m_LicenceType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());

            output.AppendLine(String.Format("Licence type : {0}", m_LicenceType));
            output.AppendLine(String.Format("Engine capacity: {0}", m_EngineCapacity));

            return output.ToString();
        }
    }
}
