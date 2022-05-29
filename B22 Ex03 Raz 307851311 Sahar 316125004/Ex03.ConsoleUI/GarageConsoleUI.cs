using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageConsoleUI
    {
        private readonly GarageManager r_GarageManager;
        private readonly Dictionary<string, eOptionChoice> r_UserMainOptions;
        private readonly Dictionary<string, VehicleGenerator.eVehicleType> r_UserVehicalTypeOption;
        private readonly Dictionary<string, eVehicleStatus> r_UserVehicalStatusOption;
        private readonly Dictionary<string, eFuelType> r_UserFuelType;
        private readonly Dictionary<string, eNumberOfDoors> r_UserCarNumberOfDoors;
        private readonly Dictionary<string, eColor> r_UserCarColor;
        private readonly Dictionary<string, eLicenceType> r_UserMotorcycleLicenceType;
        private const string k_MainMenuMessage = @"
            Welcome to our garage :) 

Please select an action and then press 'Enter'
1. To add a new vehicle press '1'
2. To see all license plate in the garage press '2'
3. To change the status of a vehicle press '3'
4. To add air to the maximum in the vehicle wheels press '4'
5. To refual a fuel vehicle press '5'
6. To recharge an electric vehicle press '6' 
7. To get information about a vehicle press '7'
8. To quit press 'q'
 ";
        private const string k_GoBackToMainMenuMessage = "\nTo go back to main menu please press 'Enter'";

        public GarageConsoleUI()
        {
            this.r_GarageManager = new GarageManager();
            this.r_UserMainOptions = new Dictionary<string, eOptionChoice>();
            r_UserMainOptions.Add("1", eOptionChoice.addVehicle);
            r_UserMainOptions.Add("2", eOptionChoice.getLicensePlates);
            r_UserMainOptions.Add("3", eOptionChoice.changeVehicleStatus);
            r_UserMainOptions.Add("4", eOptionChoice.addAirToMaximum);
            r_UserMainOptions.Add("5", eOptionChoice.refuel);
            r_UserMainOptions.Add("6", eOptionChoice.recharge);
            r_UserMainOptions.Add("7", eOptionChoice.getInfo);
            r_UserMainOptions.Add("q", eOptionChoice.quit);

            this.r_UserVehicalTypeOption = new Dictionary<string, VehicleGenerator.eVehicleType>();
            r_UserVehicalTypeOption.Add("1", VehicleGenerator.eVehicleType.FuelMotorcycle);
            r_UserVehicalTypeOption.Add("2", VehicleGenerator.eVehicleType.ElectricMotorcycle);
            r_UserVehicalTypeOption.Add("3", VehicleGenerator.eVehicleType.FualCar);
            r_UserVehicalTypeOption.Add("4", VehicleGenerator.eVehicleType.ElectricCar);
            r_UserVehicalTypeOption.Add("5", VehicleGenerator.eVehicleType.Truck);

            this.r_UserVehicalStatusOption = new Dictionary<string, eVehicleStatus>();
            r_UserVehicalStatusOption.Add("1", eVehicleStatus.InRepair);
            r_UserVehicalStatusOption.Add("2", eVehicleStatus.Repaired);
            r_UserVehicalStatusOption.Add("3", eVehicleStatus.Paid);

            this.r_UserFuelType = new Dictionary<string, eFuelType>();
            r_UserFuelType.Add("1", eFuelType.Soler);
            r_UserFuelType.Add("2", eFuelType.Octan95);
            r_UserFuelType.Add("3", eFuelType.Octan96);
            r_UserFuelType.Add("4", eFuelType.Octan98);

            this.r_UserCarNumberOfDoors = new Dictionary<string, eNumberOfDoors>();
            r_UserCarNumberOfDoors.Add("2", eNumberOfDoors.Two);
            r_UserCarNumberOfDoors.Add("3", eNumberOfDoors.Three);
            r_UserCarNumberOfDoors.Add("4", eNumberOfDoors.Four);
            r_UserCarNumberOfDoors.Add("5", eNumberOfDoors.Five);

            this.r_UserCarColor = new Dictionary<string, eColor>();
            r_UserCarColor.Add("1", eColor.Red);
            r_UserCarColor.Add("2", eColor.White);
            r_UserCarColor.Add("3", eColor.Green);
            r_UserCarColor.Add("4", eColor.Blue);

            this.r_UserMotorcycleLicenceType = new Dictionary<string, eLicenceType>();
            r_UserMotorcycleLicenceType.Add("1", eLicenceType.A);
            r_UserMotorcycleLicenceType.Add("2", eLicenceType.A1);
            r_UserMotorcycleLicenceType.Add("3", eLicenceType.B1);
            r_UserMotorcycleLicenceType.Add("4", eLicenceType.BB);
        }

        public void Run()
        {
            bool wantToQuit = true;
            string userInput;
            eOptionChoice option;

            while (wantToQuit)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(k_MainMenuMessage);
                    userInput = Console.ReadLine(); // make sure valid input for!!!!
                    option = r_UserMainOptions[userInput];

                    switch (option)
                    {
                        case eOptionChoice.addVehicle:
                            addVehicle();
                            break;
                        case eOptionChoice.getLicensePlates:
                            getLicensePlates();
                            break;
                        case eOptionChoice.changeVehicleStatus:
                            changeVehicleStatus();
                            break;
                        case eOptionChoice.addAirToMaximum:
                            addAirToMaximum();
                            break;
                        case eOptionChoice.refuel:
                            refuel();
                            break;
                        case eOptionChoice.recharge:
                            recharge();
                            break;
                        case eOptionChoice.getInfo:
                            getInfo();
                            break;
                        case eOptionChoice.quit:
                            wantToQuit = false;
                            break;
                    }
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine($"Invalid operation: {e.Message}");
                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                }

                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"The maximum valid input is: {e.MaxValue}");
                    Console.WriteLine($"The minimum valid input is: {e.MinValue}");

                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                }

                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);

                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);

                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                }

            }
        }

        private void addVehicle()
        {
            Console.Clear();
            Console.WriteLine("Please enter license plate");
            string licensePlate = Console.ReadLine();

            if (r_GarageManager.isVehicleInTheGarage(licensePlate))
            {
                try
                {
                    r_GarageManager.AddExistingVehicle(licensePlate);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            else
            {
                Console.WriteLine("Please enter owner name");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please enter owner phone number");
                string ownerPhoneNumber = Console.ReadLine();
                Console.WriteLine("Please enter model name");
                string modelName = Console.ReadLine();
                Console.WriteLine(@"Please enter vehicle type, the options are:
1. Fuel Motorcycle
2. Electric Motorcycle
3. Fual Car
4. Electric Car
5. Truck");

                string userVehicalTypeInput = Console.ReadLine(); // make sure valid input !!!!
                VehicleGenerator.eVehicleType vehicalType = r_UserVehicalTypeOption[userVehicalTypeInput];

                Console.WriteLine("Please enter wheels manufacturer name");
                string wheelsManufacturerName = Console.ReadLine();

                Console.WriteLine("Please enter current tyre Pressure");

                string userTyrePressureInput = Console.ReadLine(); // make sure input is float
                float tyrePressure = (float)Convert.ToDouble(userTyrePressureInput);

                Console.WriteLine("Please enter Current Energy");
                string userCurrentEnergyInput = Console.ReadLine(); // make sure input float
                float currentEnergy = (float)Convert.ToDouble(userCurrentEnergyInput);

                r_GarageManager.AddNewVehicle(modelName, licensePlate, vehicalType, wheelsManufacturerName, tyrePressure, currentEnergy,
                   ownerName, ownerPhoneNumber);

                switch (vehicalType)
                {
                    case VehicleGenerator.eVehicleType.FuelMotorcycle:
                        Console.WriteLine(@"Please choose license type, the options are:
1. A
2. A1
3. B1
4. BB");

                        string userInput1 = Console.ReadLine();
                        eLicenceType FuelMotorcycleLicenceType = r_UserMotorcycleLicenceType[userInput1];

                        Console.WriteLine("Please enter Engine Capacity");
                        int engineCapacity1 = Convert.ToInt32(Console.ReadLine());

                        r_GarageManager.VehicleToMotorcycle(licensePlate, FuelMotorcycleLicenceType, engineCapacity1);
                        break;

                    case VehicleGenerator.eVehicleType.ElectricMotorcycle:
                        Console.WriteLine(@"Please choose license type, the options are:
1. A
2. A1
3. B1
4. BB");

                        string userInput2 = Console.ReadLine();
                        eLicenceType ElectricMotorcycleLicenceType = r_UserMotorcycleLicenceType[userInput2];

                        Console.WriteLine("i_EngineCapacity");

                        int engineCapacity2 = Convert.ToInt32(Console.ReadLine());

                        r_GarageManager.VehicleToMotorcycle(licensePlate, ElectricMotorcycleLicenceType, engineCapacity2);
                        break;

                    case VehicleGenerator.eVehicleType.FualCar:

                        Console.WriteLine(@"Please choose car color, the options are:
1. Red
2. White
3. Green
4. Blue");

                        string userInput3 = Console.ReadLine();
                        eColor FuelCarColor = r_UserCarColor[userInput3];

                        Console.WriteLine("Please enter car number of doors, the options are: 2, 3, 4, 5");

                        string userInput4 = Console.ReadLine();
                        eNumberOfDoors FuelCarDoors = r_UserCarNumberOfDoors[userInput4];

                        r_GarageManager.VehicleToCar(licensePlate, FuelCarColor, FuelCarDoors);

                        break;

                    case VehicleGenerator.eVehicleType.ElectricCar:

                        Console.WriteLine(@"Please choose car color, the options are:
1. Red
2. White
3. Green
4. Blue");

                        string userInput5 = Console.ReadLine();
                        eColor ElectricCarColor = r_UserCarColor[userInput5];

                        Console.WriteLine(@"Please enter car number of doors, the options are:
1. Two
2. Three
3. Four
4. Five");

                        string userInput6 = Console.ReadLine();
                        eNumberOfDoors electricCarDoors = r_UserCarNumberOfDoors[userInput6];

                        r_GarageManager.VehicleToCar(licensePlate, ElectricCarColor, electricCarDoors);

                        break;
                    case VehicleGenerator.eVehicleType.Truck:
                        //cold
                        //volium 

                        Console.WriteLine("is the truck contain refrigerated contents? [y/n]");
                        string userInput7 = Console.ReadLine();
                        bool isRefrigeratedContents = false;

                        if (userInput7.Equals("y"))
                        {
                            isRefrigeratedContents = true;
                        }

                        Console.WriteLine("Please enter truck cargo volume");
                        string userInput8 = Console.ReadLine();
                        float cargoVolume = (float)Convert.ToDouble(userInput8);

                        r_GarageManager.VehicleToTruck(licensePlate, isRefrigeratedContents, cargoVolume);

                        break;
                }

            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();

        }
        private void getLicensePlates()
        {
            Console.Clear();
            // ask if user want to filter by status - if yes filter by in repair / repaired / paid
            Console.WriteLine("Do you want to filter? [y/n]");

            string wantFilter = Console.ReadLine();
            if (wantFilter.Equals("y"))
            {
                Console.WriteLine(@"Please choose an option:
1. In Repair
2. Repaired
3. Paid");

                string userChoice = Console.ReadLine();
                eVehicleStatus userEnumChoice = r_UserVehicalStatusOption[userChoice]; // make sure valid input !!!!

                Console.WriteLine(r_GarageManager.GetLicensePlateByFilter(userEnumChoice));

            }
            else
            {
                Console.WriteLine(r_GarageManager.GetAllLicensePlates());
            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void changeVehicleStatus()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Please enter license Plate");
                string licensePlate = Console.ReadLine();
                Console.WriteLine(@"Please choose new status:
1. In Repair
2. Repaired
3. Paid");

                string newVehicleStatus = Console.ReadLine();
                eVehicleStatus newStatus = r_UserVehicalStatusOption[newVehicleStatus]; // make sure valid input !!!!

                r_GarageManager.ChangeVehicleStatus(licensePlate, newStatus);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void addAirToMaximum()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Please enter license plate");
                string licensePlate = Console.ReadLine();
                r_GarageManager.AddMaxAirToVehicle(licensePlate);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void refuel()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Please enter license plate");
                string licensePlate = Console.ReadLine();
                Console.WriteLine(@"Please choose fuel type:
1. Soler
2. Octan95
3. Octan96
4. Octan98");

                string userVehicleFuelTypeInput = Console.ReadLine();
                eFuelType VehicleFuelType = r_UserFuelType[userVehicleFuelTypeInput]; // make sure valid input !!!!

                Console.WriteLine("Please enter quantity of liters to fill");
                string fuelLiters = Console.ReadLine();
                float quantityToFill = (float)Convert.ToDouble(fuelLiters);

                r_GarageManager.Refuel(licensePlate, VehicleFuelType, quantityToFill);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(String.Format("The minimum valid input is {0}", e.MinValue));
                Console.WriteLine(String.Format("The maximum valid input is {0}", e.MaxValue));
            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void recharge()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Please enter license plate");
                string licensePlate = Console.ReadLine();

                Console.WriteLine("Please enter minutes to recharge");
                string userMinutesRechargeInput = Console.ReadLine();
                float minutesRecharge = (float)Convert.ToDouble(userMinutesRechargeInput);
                r_GarageManager.Recharge(licensePlate, minutesRecharge);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(String.Format("The minimum valid input is {0}", e.MinValue));
                Console.WriteLine(String.Format("The maximum valid input is {0}", e.MaxValue));
            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void getInfo()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Please enter license plate");
                string licensePlate = Console.ReadLine();

                Console.WriteLine(r_GarageManager.GetVehicleInfo(licensePlate));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        public enum eOptionChoice
        {
            addVehicle,
            getLicensePlates,
            changeVehicleStatus,
            addAirToMaximum,
            refuel,
            recharge,
            getInfo,
            quit
        }
    }
}
