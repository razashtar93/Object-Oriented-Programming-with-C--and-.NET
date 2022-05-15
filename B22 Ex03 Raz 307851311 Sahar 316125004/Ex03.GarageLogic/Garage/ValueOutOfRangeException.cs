using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic.Garage
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;


        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
           : base(string.Format("Value of range, please use a value in the range of {0} to {1}", i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return r_MaxValue; }
        }

        public float MinValue
        {
            get { return r_MinValue; }
        }
    }
}
