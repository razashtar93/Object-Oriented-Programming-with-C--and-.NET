using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class PowerSource // Done. 
    {
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public PowerSource(float i_MaxEnergy, float i_CurrentEnergy)
        {
            this.r_MaxEnergy = i_MaxEnergy;
            this.m_CurrentEnergy = i_CurrentEnergy;
        }

        public float MaxEnergy
        {
            get { return r_MaxEnergy; }
        }

        protected float CurrentEnergy
        {
            set { m_CurrentEnergy = value; }
            get { return m_CurrentEnergy; }
        }

        public float PowerEnergyPercent
        {
            get { return (m_CurrentEnergy / r_MaxEnergy) * 100; }
        }

        public float HowMuchLeftForMaxEnergy()
        {
            return (this.r_MaxEnergy - this.m_CurrentEnergy);


        }
    }
}
