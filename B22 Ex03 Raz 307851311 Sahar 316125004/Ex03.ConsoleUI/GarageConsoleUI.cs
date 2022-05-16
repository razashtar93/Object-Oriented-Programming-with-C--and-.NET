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



        public GarageConsoleUI()
        {
            this.r_GarageManager = new GarageManager();
        }

        public void Run()
        {

        }
    
    
    
    
    
    
    
    
    }
}
