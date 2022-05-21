using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelPowerSource : PowerSource
    {
        private readonly eFuelType r_FuelType;

        public FuelPowerSource(float i_MaxEnergy, float i_CurrentEnergy, eFuelType i_FuelType) : base(i_MaxEnergy, i_CurrentEnergy)
        {
            this.r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public void Refuel(float i_FuelLiters, eFuelType i_FuelType)
        {
            float howMuchMoreFuelForMaxTank = HowMuchLeftForMaxEnergy();

            if (i_FuelType != this.r_FuelType)
            {
                throw new ArgumentException(string.Format("Wrong type of fuel, accepting fuel: {0}", r_FuelType));
            }
            if (howMuchMoreFuelForMaxTank < i_FuelLiters)
            {
                throw new ValueOutOfRangeException(0, howMuchMoreFuelForMaxTank);
            }

            base.CurrentEnergy += i_FuelLiters;
        }

        public override string ToString()
        {
            return string.Format("fuel type: {0} , Current fuel liters in the tank: {1} , max liters: {2}"
                , r_FuelType, CurrentEnergy, MaxEnergy);
        }
    }
}
