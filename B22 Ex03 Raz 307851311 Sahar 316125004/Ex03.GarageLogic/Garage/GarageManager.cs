using System;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.Garage;
using System.Collections.Generic;
using static Ex03.GarageLogic.VehicleGenerator;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        readonly Dictionary<string, VehiclesInTheGarage> r_VehiclesInTheGarage;

        public GarageManager()
        {
            r_VehiclesInTheGarage = new Dictionary<string, VehiclesInTheGarage>();
        }

        public bool isVehicleInTheGarage(string i_LicensePlate)
        {
            bool answer = false;

            foreach (KeyValuePair<string, VehiclesInTheGarage> vehicle in r_VehiclesInTheGarage)
            {
                if (vehicle.Value.Vehicle.LicencePlate.Equals(i_LicensePlate))
                {
                    answer = true;
                    break;
                }
            }

            return answer;
        }

        public void AddExistingVehicle(string i_LicensePlate)
        {
            if (r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus == eVehicleStatus.InRepair)
            {
                throw new ArgumentException("The vehicle is already in the garage and in repair status");
            }
            else
            {
                r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus = eVehicleStatus.InRepair;
            }
        }

        public void AddNewVehicle(string i_ModelName, string i_LicensePlate, eVehicleType i_VehicleType,
            string i_WheelManufacturerName, float i_WheelCurrentAirPressure, float i_CurrentEnergy, string i_OwnerName, string i_OwenerPhoneNumber)
        {
            Vehicle vehicle = VehicleGenerator.CreateVehicle(i_ModelName, i_LicensePlate, i_VehicleType, i_WheelManufacturerName, i_WheelCurrentAirPressure, i_CurrentEnergy);
            Owner owner = new Owner(i_OwnerName, i_OwenerPhoneNumber);
            VehiclesInTheGarage vehicleInTheGarage = new VehiclesInTheGarage(vehicle, owner, eVehicleStatus.InRepair);

            r_VehiclesInTheGarage.Add(i_LicensePlate, vehicleInTheGarage);
        }

        //VehicleToCar
        public void VehicleToCar(string i_LicensePlate, eColor i_Color, eNumberOfDoors i_NumberOfDoors)
        {
            Car car = r_VehiclesInTheGarage[i_LicensePlate].Vehicle as Car;
            car.NumberOfDoors = i_NumberOfDoors;
            car.CarColor = i_Color;
        }

        //VehicleToMotorcycle
        public void VehicleToMotorcycle(string i_LicensePlate, eLicenceType i_LicenceType, int i_EngineCapacity)
        {
            Motorcycle motorcycle = r_VehiclesInTheGarage[i_LicensePlate].Vehicle as Motorcycle;
            motorcycle.LicenceType = i_LicenceType;
            motorcycle.EngineCapacity = i_EngineCapacity;
        }

        //VehicleTotruck
        public void VehicleToTruck(string i_LicensePlate, bool i_RefrigeratedContents, float i_CargoVolume)
        {
            Truck truck = r_VehiclesInTheGarage[i_LicensePlate].Vehicle as Truck;
            truck.RefrigeratedContents = i_RefrigeratedContents;
            truck.CargoVolume = i_CargoVolume;
        }

        // public get all license plate of vehicle in the garage by filter
        public string GetLicensePlateByFilter(eVehicleStatus i_VehileStatus)
        {
            StringBuilder ListOfLicencePlates = new StringBuilder();

            foreach (KeyValuePair<string, VehiclesInTheGarage> vehicle in r_VehiclesInTheGarage)
            {
                if (vehicle.Value.VehicleStatus == i_VehileStatus)
                {
                    ListOfLicencePlates.Append("Car Number: " + vehicle.Key + "\n");
                }
            }

            return ListOfLicencePlates.ToString();
        }

        // public get all license plate of vehicle in the garage
        public string GetAllLicensePlates()
        {
            StringBuilder ListOfLicencePlates = new StringBuilder();

            foreach (KeyValuePair<string, VehiclesInTheGarage> vehicle in r_VehiclesInTheGarage)
            {
                ListOfLicencePlates.Append("Car Number: " + vehicle.Key + "\n");
            }

            return ListOfLicencePlates.ToString();
        }

        // public change vehicle status
        public void ChangeVehicleStatus(string i_LicensePlate, eVehicleStatus i_NewStatus)
        {
            if (!isVehicleInTheGarage(i_LicensePlate))
            {
                throw new ArgumentException("The vehicle isn't in the garage");
            }

            else
            {
                r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus = i_NewStatus;
            }
        }

        // add air presure to vehicle (max)
        public void AddMaxAirToVehicle(string i_LicensePlate)
        {
            if (!isVehicleInTheGarage(i_LicensePlate))
            {
                throw new ArgumentException("The vehicle isn't in the garage");
            }

            else
            {
                Wheel[] vehicleWheels = r_VehiclesInTheGarage[i_LicensePlate].Vehicle.Wheels;

                for (int i = 0; i < vehicleWheels.Length; i++)
                {
                    r_VehiclesInTheGarage[i_LicensePlate].Vehicle.Wheels[i].CurrentAirPressure = r_VehiclesInTheGarage[i_LicensePlate].Vehicle.Wheels[i].MaxAirPressure;
                }
            }
        }

        // refuel 
        public void Refuel(string i_LicensePlate, eFuelType i_FuelType, float i_FuelLiters)
        {
            FuelPowerSource fuelPowerSourceObj = (r_VehiclesInTheGarage[i_LicensePlate].Vehicle.PowerSource as FuelPowerSource);

            if (!isVehicleInTheGarage(i_LicensePlate))
            {
                throw new ArgumentException("The vehicle isn't in the garage");
            }

            if (fuelPowerSourceObj == null)
            {
                throw new ArgumentException("You can`t refuel an electric vehicle");
            }

            try
            {
                (r_VehiclesInTheGarage[i_LicensePlate].Vehicle.PowerSource as FuelPowerSource).Refuel(i_FuelLiters, i_FuelType);
            }

            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }

            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e.MinValue, e.MaxValue);
            }
        }

        // public void recharge
        public void Recharge(string i_LicensePlate, float i_MinutesToCharge)
        {
            ElectricPowerSource electricPowerSourceObj = (r_VehiclesInTheGarage[i_LicensePlate].Vehicle.PowerSource as ElectricPowerSource);
            float hoursToCharge = i_MinutesToCharge / 60;

            if (!isVehicleInTheGarage(i_LicensePlate))
            {
                throw new ArgumentException("The vehicle isn't in the garage");
            }

            if (electricPowerSourceObj == null)
            {
                throw new ArgumentException("You can`t recharge a fuel vehicle");
            }

            try
            {
                (r_VehiclesInTheGarage[i_LicensePlate].Vehicle.PowerSource as ElectricPowerSource).Recharge(hoursToCharge);
            }

            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e.MaxValue, e.MinValue);
            }
        }

        // public get info of vehicle
        public string GetVehicleInfo(string i_LicensePlate)
        {
            if (!isVehicleInTheGarage(i_LicensePlate))
            {
                throw new ArgumentException("The vehicle isn't in the garage");
            }

            StringBuilder VehicleInfo = new StringBuilder();
            VehicleInfo.Append(r_VehiclesInTheGarage[i_LicensePlate].Vehicle.ToString());
            VehicleInfo.Append(String.Format("Vehicle owner: {0}\n", r_VehiclesInTheGarage[i_LicensePlate].Owner.ToString()));
            VehicleInfo.Append(String.Format("Vehicle status: {0}", r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus));

            return VehicleInfo.ToString();
        }
    }
}
