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

        public bool isVehicleInTheGarage(string i_LicensePlate)
        {
            bool answer = false;

            foreach (KeyValuePair<string, VehiclesInTheGarage> vehicle in r_VehiclesInTheGarage)
            {
                if (vehicle.Value.Vehicle.LicencePlate == i_LicensePlate)
                {
                    answer = true;
                    break;
                }
            }

            return answer;
        }

        public void AddExistingVehicle(string i_LicensePlate)
        {
            //VehiclesInTheGarage vehicleInTheGarage = r_VehiclesInTheGarage[i_LicensePlate];
            if (r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus == eVehicleStatus.InRepair)
            {
                throw new ArgumentException("The vehicle is already in the garage and in repair status");
            }
            else
            {
                //vehicleInTheGarage.VehicleStatus = eVehicleStatus.InRepair;
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





        //public void AddNewVehicle(Vehicle i_VehicleToAdd, Owner i_NewVehicleOwner) // need to create here the owner! we get name and phone number from the user .. 
        //{ // also need to create a vehicle object .. the user only give a license Plate
        //    if (r_VehiclesInTheGarage.ContainsKey(i_VehicleToAdd.LicencePlate) &&
        //        r_VehiclesInTheGarage[i_VehicleToAdd.LicencePlate].VehicleStatus == eVehicleStatus.InRepair)
        //    {
        //        throw new ArgumentException("The vehicle is already in the garage");
        //    }
        //    else
        //    {
        //        if (r_VehiclesInTheGarage.ContainsKey(i_VehicleToAdd.LicencePlate))
        //        {
        //            //only change status
        //            VehiclesInTheGarage vehicleInTheGarage = r_VehiclesInTheGarage[i_VehicleToAdd.LicencePlate];
        //            vehicleInTheGarage.VehicleStatus = eVehicleStatus.InRepair;
        //        }
        //        else
        //        {
        //            VehiclesInTheGarage vehiclesInTheGarageToAdd = new VehiclesInTheGarage(i_VehicleToAdd, i_NewVehicleOwner, eVehicleStatus.InRepair);
        //            r_VehiclesInTheGarage.Add(i_VehicleToAdd.LicencePlate, vehiclesInTheGarageToAdd);
        //        }
        //    }
        //}

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
            r_VehiclesInTheGarage[i_LicensePlate].Vehicle.PowerSource.fuel

                try
            {

            }
            catch(ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }




        }

        //Refuel(float i_FuelLiters, eFuelType i_FuelType)


        // public void recharge



        // public get info of vehicle
        public string GetVehicleInfo(string i_LicensePlate)
        {
            StringBuilder VehicleInfo = new StringBuilder();
            VehicleInfo.Append(r_VehiclesInTheGarage[i_LicensePlate].Vehicle.ToString());
            VehicleInfo.Append(String.Format("Vehicle owner: {0}", r_VehiclesInTheGarage[i_LicensePlate].Owner.ToString()));
            VehicleInfo.Append(String.Format("Vehicle status: {0}", r_VehiclesInTheGarage[i_LicensePlate].VehicleStatus));

            return VehicleInfo.ToString();
        }

    }
}
