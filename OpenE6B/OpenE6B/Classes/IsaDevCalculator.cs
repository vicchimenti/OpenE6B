using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenE6B.Classes
{
    public class IsaDevCalculator
    {
        public string GetDeviation(int altitude, int temperature)
        {
            string returnString;
            float deviation;


            if (altitude < 36000)
            {
                var isaTemp = (altitude/1000)* -1 + 15;
                deviation = temperature - isaTemp;
                return deviation >= 0 ? $"ISA +{deviation}" : $"ISA {deviation}";
            }
            else
            {
                var isaTemp = -57;
                deviation = temperature - isaTemp;
                return deviation >= 0 ? $"ISA +{deviation}" : $"ISA {deviation}";
            }

        }
    }
}
