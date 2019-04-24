using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenE6B.Classes.Tests
{
    [TestClass()]
    public class IsaDevCalculatorTests
    {
        IsaDevCalculator isaDevObj = new IsaDevCalculator();
        // TBD: Next milestone add negative (Assert.AreNotEqual) Test Cases

        [TestMethod()]
        public void GetDeviationZeroAltitudeZeroTemperatureTest()
        {
            // Default values of 0 and 0
            Assert.AreEqual("ISA -15", isaDevObj.GetDeviation(0, 0));
        }

        [TestMethod()]
        public void GetDeviationLowAltitudeTest()
        {
            // Altitude less than 36000
            Assert.AreEqual("ISA +45", isaDevObj.GetDeviation(30000, 30));
        }

        [TestMethod()]
        public void GetDeviationLowAltitudeLowTemperatureTest()
        {
            // Altitude greater than 36000, -10 Celsius temperature
            Assert.AreEqual("ISA -15", isaDevObj.GetDeviation(10000, -10));
        }

        [TestMethod()]
        public void GetDeviationHighAltitudeTest()
        {
            // Altitude greater than 36000
            Assert.AreEqual("ISA +74", isaDevObj.GetDeviation(39000, 17));
        }

        [TestMethod()]
        public void GetDeviationHighAltitudeLowTemperatureTest()
        {
            // Altitude greater than 36000, -58 Celsius temperature
            Assert.AreEqual("ISA -1", isaDevObj.GetDeviation(40000, -58));
        }

        [TestMethod()]
        public void GetDeviationHighAltitudeHighTemperatureTest()
        {
            // Altitude greater than 36000, 55 Celsius temperature
            Assert.AreEqual("ISA +112", isaDevObj.GetDeviation(40000, 55));
        }
    }
}