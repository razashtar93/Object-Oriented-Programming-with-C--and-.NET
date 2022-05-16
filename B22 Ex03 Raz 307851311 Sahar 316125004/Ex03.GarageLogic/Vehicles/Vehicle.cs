using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.Garage.VehicleGenerator;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle // Maybe Done.
    {
        private readonly string r_ModelName;
        private readonly string r_LicencePlate;
        private readonly Wheel[] r_Wheels;
        private PowerSource.PowerSource m_PowerSource;
        private readonly eVehicleType r_VehicleType;


        protected Vehicle(string i_ModelName, string i_LicencePlate, Wheel[] i_Wheels, PowerSource.PowerSource i_PowerSource, eVehicleType i_VehicleType)
        {
            this.r_ModelName = i_ModelName;
            this.r_LicencePlate = i_LicencePlate;
            this.r_Wheels = i_Wheels;
            this.m_PowerSource = i_PowerSource;
            this.r_VehicleType = i_VehicleType;
        }


        public string ModelName
        {
            get { return r_ModelName; }
        }

        public string LicencePlate
        {
            get { return r_LicencePlate; }
        }

        public Wheel[] Wheels
        {
            get { return r_Wheels; }
        }

        public PowerSource.PowerSource PowerSource
        {
            get { return m_PowerSource; }
            set { m_PowerSource = value; }
        }

        public eVehicleType VehicleType
        {
            get { return r_VehicleType; }
        }


        public override string ToString()
        {
            string wheels = wheelsToString(Wheels);
            string output = String.Format(@"
Licence Plate: {0}
Vehicle model name: {1}
Type: {2}
Wheels info: 
{3}
Power source info:
{4}
", r_ModelName, r_LicencePlate, r_VehicleType, wheels, PowerSource.ToString());

            return output;
        }

        private string wheelsToString(Wheel[] i_Wheels)
        {
            StringBuilder outputstringWheels = new StringBuilder();

            foreach (Wheel wheel in i_Wheels)
            {
                outputstringWheels.AppendLine(wheel.ToString());
            }

            return outputstringWheels.ToString();
        }

        //public static Dictionary<int, eVehicleType> GetVehicleTypeDictionary()
        //{
        //    return DictUtils.GetEnumDictionary<eVehicleType>();
        //}
    }
}
