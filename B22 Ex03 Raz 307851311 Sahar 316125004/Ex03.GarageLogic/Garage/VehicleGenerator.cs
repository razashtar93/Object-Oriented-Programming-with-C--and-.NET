using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Garage
{
    class VehicleGenerator
    {
        private const int k_NumberOfWheelsMotorcycleFuel = 2;
        private const float k_MaxAirPressureInWheelsMotorcycleFuel = 31;
        private const Vehicles.PowerSource.eFuelType k_FuelTypeMotorcycleFuel = Vehicles.PowerSource.eFuelType.Octan98;
        private const float k_TankFuelMotorcycleFuel = 6.2f;

        private const int k_NumberOfWheelsMotorcycleElectric = 2;
        private const float k_MaxAirPressureInWheelsMotorcycleElectric = 31;
        private const float k_MaximumBatteryLifeMotorcycleElectric = 2.5f;

        private const int k_NumberOfWheelsCarFuel = 4;
        private const float k_MaxAirPressureInWheelsCarFuel = 29;
        private const Vehicles.PowerSource.eFuelType k_FuelTypeCarFuel = Vehicles.PowerSource.eFuelType.Octan95;
        private const float k_TankFuelCarFuel = 38f;


        private const int k_NumberOfWheelsCarElectric = 4;
        private const float k_MaxAirPressureInWheelsCarElectric = 29;
        private const float k_MaximumBatteryLifeCarElectric = 3.3f;

        private const int k_NumberOfWheelsTruckFuel= 16;
        private const float k_MaxAirPressureInWheelsTruckFuel = 24;
        private const Vehicles.PowerSource.eFuelType k_FuelTypeTruckFuel = Vehicles.PowerSource.eFuelType.Soler;
        private const float k_TankFuelTruckFuel = 120f;







        public enum eVehicleType
        {
            FuelMotorcycle,
            ElectricMotorcycle,
            FualCar,
            ElectricCar,
            Truck
        }



    }
}
