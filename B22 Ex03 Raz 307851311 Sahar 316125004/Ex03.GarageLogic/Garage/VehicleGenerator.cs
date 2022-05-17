using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleType // when we want to add another type of vehicle we add the type here
        {
            FuelMotorcycle,
            ElectricMotorcycle,
            FualCar,
            ElectricCar,
            Truck
        }

        //Fuel Motorcycle
        private const int k_FuelMotorcycleNumberOfWheels = 2;
        private const float k_FuelMotorcycleMaxAirPressureInWheels = 31;
        private const eFuelType k_FuelMotorcycleFuelType = eFuelType.Octan98;
        private const float k_FuelMotorcycleTankFuel = 6.2f;

        //Electric Motorcycle
        private const int k_ElectricMotorcycleNumberOfWheels = 2;
        private const float k_ElectricMotorcycleMaxAirPressureInWheels = 31;
        private const float k_ElectricMotorcycleMaximumBatteryLife = 2.5f;

        //Fual Car
        private const int k_FualCarNumberOfWheels = 4;
        private const float k_FualCarMaxAirPressureInWheels = 29;
        private const eFuelType k_FualCarFuelType = eFuelType.Octan95;
        private const float k_FualCarTankFuel = 38f;

        //Electric Car
        private const int k_ElectricCarNumberOfWheels = 4;
        private const float k_ElectricCarMaxAirPressureInWheels = 29;
        private const float k_ElectricCarMaximumBatteryLife = 3.3f;

        //Truck
        private const int k_TruckNumberOfWheels = 16;
        private const float k_TruckMaxAirPressureInWheels = 24;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private const float k_TruckTankFuel = 120f;


        public static Vehicle CreateVehicle(string i_ModelName, string i_LicencePlate, eVehicleType i_VehicleType, string i_WheelManufacturerName, float i_WheelCurrentAirPressure, float i_CurrentEnergy)
        {
            Vehicle newVehicle = null;
            PowerSource powerSource;
            Wheel[] wheels;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    wheels = createWheels(k_FuelMotorcycleNumberOfWheels, i_WheelManufacturerName,
                        i_WheelCurrentAirPressure, k_FuelMotorcycleMaxAirPressureInWheels);

                    powerSource = new FuelPowerSource(k_FuelMotorcycleTankFuel, i_CurrentEnergy, k_FuelMotorcycleFuelType);

                    newVehicle = new Motorcycle(i_ModelName, i_LicencePlate, wheels, powerSource, i_VehicleType);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    wheels = createWheels(k_ElectricMotorcycleNumberOfWheels, i_WheelManufacturerName,
                        i_WheelCurrentAirPressure, k_ElectricMotorcycleMaxAirPressureInWheels);

                    powerSource = new ElectricPowerSource(k_ElectricMotorcycleMaximumBatteryLife, i_CurrentEnergy);

                    newVehicle = new Motorcycle(i_ModelName, i_LicencePlate, wheels, powerSource, i_VehicleType);
                    break;

                case eVehicleType.FualCar:
                    wheels = createWheels(k_FualCarNumberOfWheels, i_WheelManufacturerName,
                        i_WheelCurrentAirPressure, k_FualCarMaxAirPressureInWheels);

                    powerSource = new FuelPowerSource(k_FualCarTankFuel, i_CurrentEnergy, k_FualCarFuelType);

                    newVehicle = new Car(i_ModelName, i_LicencePlate, wheels, powerSource, i_VehicleType);
                    break;

                case eVehicleType.ElectricCar:
                    wheels = createWheels(k_ElectricCarNumberOfWheels, i_WheelManufacturerName,
                        i_WheelCurrentAirPressure, k_ElectricCarMaxAirPressureInWheels);

                    powerSource = new ElectricPowerSource(k_ElectricCarMaximumBatteryLife, i_CurrentEnergy);

                    newVehicle = new Car(i_ModelName, i_LicencePlate, wheels, powerSource, i_VehicleType);
                    break;

                case eVehicleType.Truck:
                    wheels = createWheels(k_TruckNumberOfWheels, i_WheelManufacturerName,
                       i_WheelCurrentAirPressure, k_TruckMaxAirPressureInWheels);

                    powerSource = new FuelPowerSource(k_TruckTankFuel, i_CurrentEnergy, k_TruckFuelType);

                    newVehicle = new Truck(i_ModelName, i_LicencePlate, wheels, powerSource, i_VehicleType);
                    break;
            }

            return newVehicle;
        }



        private static Wheel[] createWheels(int i_NumberOfWheels, string i_WheelManufacturerName, float i_WheelCurrentAirPressure, float i_MaxAirPressure)
        {
            Wheel[] wheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                wheels[i] = new Wheel(i_WheelManufacturerName, i_WheelCurrentAirPressure, i_MaxAirPressure);
            }

            return wheels;

        }


        public static float GetVehicleMaxEnergy(eVehicleType i_VehicleType)
        {
            float maxEnergy = 0;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    maxEnergy = k_FuelMotorcycleTankFuel;
                    break;

                case eVehicleType.ElectricMotorcycle:
                    maxEnergy = k_ElectricMotorcycleMaximumBatteryLife;
                    break;

                case eVehicleType.FualCar:
                    maxEnergy = k_FualCarTankFuel;
                    break;

                case eVehicleType.ElectricCar:
                    maxEnergy = k_ElectricCarMaximumBatteryLife;
                    break;

                case eVehicleType.Truck:
                    maxEnergy = k_TruckTankFuel;
                    break;
            }

            return maxEnergy;
        }


        public static float GetVehicleMaxAirPressurre(eVehicleType i_VehicleType)
        {
            float maxAir = 0;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelMotorcycle:
                    maxAir = k_FuelMotorcycleMaxAirPressureInWheels;
                    break;

                case eVehicleType.ElectricMotorcycle:
                    maxAir = k_ElectricMotorcycleMaxAirPressureInWheels;
                    break;

                case eVehicleType.FualCar:
                    maxAir = k_FualCarMaxAirPressureInWheels;
                    break;



                case eVehicleType.ElectricCar:
                    maxAir = k_ElectricCarMaxAirPressureInWheels;
                    break;

                case eVehicleType.Truck:
                    maxAir = k_TruckMaxAirPressureInWheels;
                    break;
            }

            return maxAir;
        }






    }
}
