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
        // list or dictionary of vehicles in the garage which will initialize in the constructor
        //private List<Vehicle> m_VehiclesList = new List<Vehicle>();

        readonly Dictionary<string, VehiclesInTheGarage> r_VehiclesInTheGarage;


        public GarageManager()
        {
            r_VehiclesInTheGarage = new Dictionary<string, VehiclesInTheGarage>();
        }

        public void AddNewVehicle(Vehicle i_VehicleToAdd, Owner i_NewVehicleOwner)
        {
            if (r_VehiclesInTheGarage.ContainsKey(i_VehicleToAdd.LicencePlate))
            {
                throw new ArgumentException("The vehicle is already in the garage");
            }

            else
            {
                VehiclesInTheGarage vehiclesInTheGarageToAdd = new VehiclesInTheGarage(i_VehicleToAdd, i_NewVehicleOwner, eVehicleStatus.InRepair);
                r_VehiclesInTheGarage.Add(i_VehicleToAdd.LicencePlate, vehiclesInTheGarageToAdd);
            }
        }

        // public get all license plate of vehicle in the garage by filter
        public string GetLicensePlateByFilter(eVehicleStatus i_VehileStatus)
        {
            StringBuilder ListOfLicencePlates = new StringBuilder();

            foreach (KeyValuePair<string, VehiclesInTheGarage> vehicle in r_VehiclesInTheGarage)
            {
                if (vehicle.Value.VehicleStatus == i_VehileStatus)
                {
                    ListOfLicencePlates.Append(vehicle.Key);
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
                    ListOfLicencePlates.Append(vehicle.Key);
            }

            return ListOfLicencePlates.ToString();
        }


        // public change vehicle status
        public void ChangeVehicleStatus(string i_LicensePlate, eVehicleStatus i_NewStatus)
        {
            if (!r_VehiclesInTheGarage.ContainsKey(i_LicensePlate))
            {
                throw new ArgumentException("The vehicle isn't in the garage");
            }

            else
            {
                r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus = i_NewStatus;
            }
        }

        // add air presure to car (max)
         public void addMaxAirToVehicle(string i_LicensePlate)
        {
            if (!r_VehiclesInTheGarage.ContainsKey(i_LicensePlate))
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
         public void refuel(string i_LicensePlate, eFuelType i_FuelType, float i_FuelLiters)
        {
            r_VehiclesInTheGarage[i_LicensePlate].Vehicle
        }

            //Refuel(float i_FuelLiters, eFuelType i_FuelType)


        // public void recharge

        // public get info of vehicle

        //
    }
}
