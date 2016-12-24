using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenE6B.Classes
{
    public class WindComponentSolver
    {
        /// <summary>
        /// Method to return
        /// </summary>
        /// <param name="windSpeed"></param>
        /// <param name="windDirection"></param>
        /// <param name="runwayDirection"></param>
        /// <returns></returns>
        public string CalculateWind(int windSpeed, int windDirection, int runwayDirection)
        {
            windDirection += 360;
            runwayDirection += 360;
            var diffWind = windDirection - runwayDirection;

            var longitudeComponent = Math.Round(windSpeed*Math.Cos(diffWind * (Math.PI / 180.0)),1);
            var lateralComponent = Math.Round(windSpeed*Math.Sin(diffWind * (Math.PI / 180.0)),1);
            var hwTw = longitudeComponent > 0 ? "Headwind" : "Tailwind";
            if (Math.Abs(lateralComponent) > 0)
            {
                longitudeComponent = longitudeComponent > 0 ? windSpeed - Math.Abs(lateralComponent) : longitudeComponent;
            }

            var cross = lateralComponent < 0 ? "Right" : "Left";

            return $"{hwTw} of {Math.Abs(longitudeComponent)} kts, Crosswind of {Math.Abs(lateralComponent)} kts from the {cross}";
        }
    }
}
