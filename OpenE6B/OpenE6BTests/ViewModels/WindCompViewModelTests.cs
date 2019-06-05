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
    public class WindCompViewModelTests
    {
        [TestMethod()]
        public void WindCompViewModelTest()
        {
            WindCompViewModel wcv = new WindCompViewModel();
            //var privateObject = new PrivateObject(wcv);

            wcv.WindDirection = 45;
            wcv.WindSpeed = 120;
            wcv.RunwayHeading = 55;

            Assert.AreEqual(45, wcv.WindDirection);
            Assert.AreEqual(120, wcv.WindSpeed);
            Assert.AreEqual(55, wcv.RunwayHeading);
        }
    }
}