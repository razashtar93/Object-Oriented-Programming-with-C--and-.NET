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
        private readonly Dictionary<string, eOptionChoice> r_UserOptions;
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
8. To quit press 'q'"; // think about something else to say maybe ...
        private const string k_GoBackToMainMenuMessage = "To go back to main menu please press 'Enter'";



        public GarageConsoleUI()
        {
            this.r_GarageManager = new GarageManager();
            this.r_UserOptions = new Dictionary<string, eOptionChoice>();
            r_UserOptions.Add("1", eOptionChoice.addVehicle);
            r_UserOptions.Add("2", eOptionChoice.getLicensePlates);
            r_UserOptions.Add("3", eOptionChoice.changeVehicleStatus);
            r_UserOptions.Add("4", eOptionChoice.addAirToMaximum);
            r_UserOptions.Add("5", eOptionChoice.refuel);
            r_UserOptions.Add("6", eOptionChoice.recharge);
            r_UserOptions.Add("7", eOptionChoice.getInfo);
            r_UserOptions.Add("q", eOptionChoice.quit);
        }

        public void Run()
        {
            bool wantToQuit = false;
            string userInput;
            eOptionChoice option;

            while (wantToQuit)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(k_MainMenuMessage);
                    userInput = Console.ReadLine(); // make sure valid input for ""option !!!!
                    option = r_UserOptions[userInput];

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



        // Console.WriteLine("Please enter ");

        private void addVehicle() //TODO: Implement this
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
                Console.WriteLine("Please enter vehicle type");
                string vehicalType = Console.ReadLine(); //string vehicle type -> need to change to enum
                Console.WriteLine("Please enter wheels manufacturer name");
                string wheelsManufacturerName = Console.ReadLine();
                Console.WriteLine("Please enter current tyre Pressure");
                string tyrePressure = Console.ReadLine(); // change this to float or int or whatever
                Console.WriteLine("Please enter Current Energy");
                string currentEnergy = Console.ReadLine(); // change this to float or int or whatever


                r_GarageManager.AddNewVehicle(modelName, licensePlate, vehicalType, wheelsManufacturerName, tyrePressure, currentEnergy,
                   ownerName, ownerPhoneNumber);


                Console.WriteLine(k_GoBackToMainMenuMessage);
                Console.ReadLine();
            }
        }

        private void getLicensePlates() //TODO: Implement this
        {
            Console.Clear();
            // ask if user want to filter by status - if yes filter by in repair / repaired / paid


            /* Body of function */


            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void changeVehicleStatus() //TODO: Implement this
        {
            Console.Clear();
            //


            /* Body of function */


            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void addAirToMaximum() //TODO: Implement this
        {
            Console.Clear();
            //


            /* Body of function */


            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void refuel() //TODO: Implement this
        {
            Console.Clear();
            //
            //if the vehicle is not a fuel vehicle then exception or print error
            // else get license plate fuel type and how much to fill and do
            // GarageManager.refuel(license, type, howMuchTo);


            /* Body of function */


            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void recharge() //TODO: Implement this
        {
            Console.Clear();
            //

            //Body of function

            Console.WriteLine(k_GoBackToMainMenuMessage);
            Console.ReadLine();
        }

        private void getInfo() //TODO: Implement this
        {
            Console.Clear();
            //

            /* Body of function */

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
