using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricPowerSource : PowerSource
    {
        public ElectricPowerSource(float i_MaxEnergy, float i_CurrentEnergy) : base(i_MaxEnergy, i_CurrentEnergy)
        {
            
        }

        public void Recharge(float i_Hours)
        {
            float howMuchMoreToRecharge = HowMuchLeftForMaxEnergy();

            if (howMuchMoreToRecharge < i_Hours)
            {
                throw new ValueOutOfRangeException(0, howMuchMoreToRecharge);
            }

            base.CurrentEnergy += i_Hours;
        }


        public override string ToString()
        {
            return string.Format("Battery current hours: {0} , max hours: {1}", CurrentEnergy, MaxEnergy);
        }
    }
}
