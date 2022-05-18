using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ConsoleInputValidation
    {
        public static float CehckAirPresureValidation(float i_CurrentAirPresure, float i_AirPresureToAdd, float i_MaxAirPresureAllowed)
        {
            while(i_CurrentAirPresure + i_AirPresureToAdd > i_MaxAirPresureAllowed)
            {
                ConsoleMessages.InValideInputeError();
                i_AirPresureToAdd = float.Parse(Console.ReadLine());
            }

            return i_AirPresureToAdd;
        }

    }
}
