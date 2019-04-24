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
    public class WindComponentSolverTests
    {
        WindComponentSolver wCS = new WindComponentSolver();

        [TestMethod()]
        public void CalculateWindTest()
        {
            string expected = string.Format("Headwind of {0} kts, Crosswind of {1} kts from the {2}",
                                19.3, 0.7, "Right");

            Assert.AreEqual(expected, wCS.CalculateWind(20, 5, 7));
        }

        [TestMethod()]
        public void CalculateWindNegativeTest()
        {
            string expected = string.Format("Tailwind of {0} kts, Crosswind of {1} kts from the {2}",
                                19.3, 0.7, "Right");

            Assert.AreNotEqual(expected, wCS.CalculateWind(20, 5, 7));
        }

        [TestMethod()]
        public void CalculateWindZeroValuesTest()
        {
            string expected = string.Format("Tailwind of {0} kts, Crosswind of {1} kts from the {2}",
                                0, 0, "Left");

            Assert.AreEqual(expected, wCS.CalculateWind(0, 0, 0));
        }

        [TestMethod()]
        public void CalculateWindNegativeWinSpeedTest()
        {
            string expected = string.Format("Tailwind of {0} kts, Crosswind of {1} kts from the {2}",
                                6.4, 7.7, "Right");

            Assert.AreEqual(expected, wCS.CalculateWind(-10, 60, 10));
        }

        [TestMethod()]
        public void CalculateWindNegativeDirectionTest()
        {
            string expected = string.Format("Tailwind of {0} kts, Crosswind of {1} kts from the {2}",
                                41, 112.8, "Right");

            Assert.AreEqual(expected, wCS.CalculateWind(120, -90, 20));
        }

        [TestMethod()]
        public void CalculateWindNegativeRunWayDirectionTest()
        {
            string expected = string.Format("Tailwind of {0} kts, Crosswind of {1} kts from the {2}",
                                84.9, 84.9, "Left");

            Assert.AreEqual(expected, wCS.CalculateWind(120, 90, -45));
        }
    }
}