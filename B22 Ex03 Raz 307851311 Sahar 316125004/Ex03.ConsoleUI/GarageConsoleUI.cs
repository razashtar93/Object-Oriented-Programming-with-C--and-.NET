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
 "; // think about something else to say maybe ...
        private const string k_GoBackToMainMenuMessage = "To go back to main menu please press 'Enter'";



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

                            //default:
                            //    Console.WriteLine("Invalid input, please choose again.");
                            //    break;
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
            if (wantFilter == "y")
            {
                Console.WriteLine(@"Please choose an option:
1. In Repair
2. Repaired
3. Paid");

                string userChoice = Console.ReadLine();
                eVehicleStatus userEnumChoice = r_UserVehicalStatusOption[userChoice]; // make sure valid input !!!!

                r_GarageManager.GetLicensePlateByFilter(userEnumChoice);

            }
            else
            {
                r_GarageManager.GetAllLicensePlates();
            }


            Console.WriteLine("\n" + k_GoBackToMainMenuMessage);
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
                Console.WriteLine($"The minimum valid input is {0}", e.MinValue);
                Console.WriteLine($"The maximum valid input is {0}", e.MaxValue);
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
                Console.WriteLine($"The minimum valid input is {0}", e.MinValue);
                Console.WriteLine($"The maximum valid input is {0}", e.MaxValue);
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
