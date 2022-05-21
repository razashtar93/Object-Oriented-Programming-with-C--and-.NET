using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Garage
{
    class VehiclesInTheGarage
    {
        private readonly Vehicle r_Vechile; // the vehicle in the garage
        private readonly Owner r_Owner; // the owner name and phone
        private eVehicleStatus m_VehicleStatus; // status in garage

        public VehiclesInTheGarage(Vehicle i_Vechile, Owner i_Owner, eVehicleStatus i_VehicleStatus)
        {
            this.r_Vechile = i_Vechile;
            this.r_Owner = i_Owner;
            this.m_VehicleStatus = i_VehicleStatus;
        }

        public Vehicle Vehicle
        {
            get { return r_Vechile; }
        }

        public Owner Owner
        {
            get { return r_Owner; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }
    }
}
