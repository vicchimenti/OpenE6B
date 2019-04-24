using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenE6B.ViewModels.Tests
{
    [TestClass()]
    public class MetarTafViewModelTests
    {
        MetarTafViewModel metar = new MetarTafViewModel();

        [TestMethod()]
        public void MetarTafViewModelStationIdTest()
        {
            // Test StationId Property
            metar.StationId = "abcd";
            Assert.AreEqual("abcd", metar.StationId);
        }

        [TestMethod()]
        public void MetarTafViewModelRawMetarTextTest()
        {
            // Test RawMetarText Property
            metar.RawMetarText = "This is a Raw Text";
            Assert.AreEqual("This is a Raw Text", metar.RawMetarText);
        }

        [TestMethod()]
        public void CanRetrievePositiveTest()
        {
            metar.StationId = "abcd";

            // Test the CanRetrieve method
            Assert.IsTrue(metar.CanRetrieve());
        }

        [TestMethod()]
        public void CanRetrieveNegativeTest()
        {
            metar.StationId = "zzz";

            // Test the CanRetrieve method with an invalid Station Id
            Assert.IsFalse(metar.CanRetrieve());
        }

        [TestMethod()]
        public void CanRetrieveEmptyStationIdTest()
        {
            metar.StationId = "";

            // Test the CanRetrieve method with an empty Station Id
            Assert.IsFalse(metar.CanRetrieve());
        }
    }
}