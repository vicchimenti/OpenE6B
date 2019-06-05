using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Moq;

namespace OpenE6B.Classes.Tests
{
    [TestClass()]
    public class MetarRetrieverTests
    {
        MetarRetriever mr = new MetarRetriever();

        [TestMethod()]
        public void MetarTest()
        {

            var metar_mock = new Mock<Metar>();

            metar_mock.Object.DewPoint = 11.7f;
            metar_mock.Object.RawText = "KSEA 231822Z 29006KT 7SM SCT006 16/12 A3002 RMK AO2 T01560117";
            metar_mock.Object.SkyCondition = "Scattered at 600 ft. ";
            metar_mock.Object.Temp = 15.6f;
            metar_mock.Object.Time = new DateTime(2019, 5, 23, 6, 22, 00);
            metar_mock.Object.Visibility = 7;
            string wind = "290 degrees @ 6 Kts";
            metar_mock.Object.WindDirection = 290;
            metar_mock.Object.WindSpeed = 6;

            Assert.AreEqual(11.7f, metar_mock.Object.DewPoint);
            Assert.AreEqual("KSEA 231822Z 29006KT 7SM SCT006 16/12 A3002 RMK AO2 T01560117", metar_mock.Object.RawText);
            Assert.AreEqual("Scattered at 600 ft. ", metar_mock.Object.SkyCondition);
            Assert.AreEqual(15.6f, metar_mock.Object.Temp);
            Assert.AreEqual(new DateTime(2019, 5, 23, 6, 22, 00), metar_mock.Object.Time);
            Assert.AreEqual(7, metar_mock.Object.Visibility);
            Assert.AreEqual(290, metar_mock.Object.WindDirection);
            Assert.AreEqual(6, metar_mock.Object.WindSpeed);
            Assert.AreEqual(wind, metar_mock.Object.Wind);

        }

        [TestMethod()]
        public void GetMetarTest()
        {
            var mock = new Mock<MetarRetriever>();

            string station = "ksea";

            var ta = mock.Object;
            // var metar = helper(station);
            helper(station);

        }

        private static async void helper(string station)
        {
            var mock = new Mock<MetarRetriever>();
            var metar = await mock.Object.GetMetar(station);
            //return Metar;
        }

        [TestMethod()]
        public void ConvertSkyConditionFewTest()
        {
            // Testing a private method
            var privateObject = new PrivateObject(mr);
            var output = (string)privateObject.Invoke("ConvertSkyCondition", "FEW", "29000");

            Assert.AreEqual("Few clouds at 29000 ft. ", output);

        }

        [TestMethod()]
        public void ConvertSkyConditionClearTest()
        {
            var privateObject = new PrivateObject(mr);
            var output = (string)privateObject.Invoke("ConvertSkyCondition", "CLR", "29000");

            Assert.AreEqual("Clear", output);

        }

        [TestMethod()]
        public void ConvertSkyConditionSCTTest()
        {
            var privateObject = new PrivateObject(mr);
            var output = (string)privateObject.Invoke("ConvertSkyCondition", "SCT", "29000");

            Assert.AreEqual("Scattered at 29000 ft. ", output);

        }

        [TestMethod()]
        public void ConvertSkyConditionBKNTest()
        {
            var privateObject = new PrivateObject(mr);
            var output = (string)privateObject.Invoke("ConvertSkyCondition", "BKN", "29000");

            Assert.AreEqual("Broken at 29000 ft. ", output);

        }

        [TestMethod()]
        public void ConvertSkyConditionOVCTest()
        {
            var privateObject = new PrivateObject(mr);
            var output = (string)privateObject.Invoke("ConvertSkyCondition", "OVC", "29000");

            Assert.AreEqual("Overcast at 29000 ft. ", output);

        }

        [TestMethod()]
        public void ConvertSkyConditionFOOTest()
        {
            var privateObject = new PrivateObject(mr);
            var output = (string)privateObject.Invoke("ConvertSkyCondition", "FOO", "29000");

            Assert.AreEqual("FOO at 29000 ft. ", output);

        }


        [TestMethod()]
        public void MetarRetrieverAirportNotFoundExceptionTest()
        {

            string metarElement = null;
            try
            {
                if (metarElement == null)
                    throw new AirportNotFoundException("Invalid Station ID Entered: No METARs found");
            }
            catch (Exception e)
            {
                //  Expected exception caught!!!
                Assert.AreEqual("Invalid Station ID Entered: No METARs found", e.Message);
            }
            
        }

    }
}