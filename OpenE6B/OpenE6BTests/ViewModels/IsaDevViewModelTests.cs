using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace OpenE6B.ViewModels.Tests
{
    [TestClass()]
    public class IsaDevViewModelTests
    {
        IsaDevViewModel isa = new IsaDevViewModel();

        [TestMethod()]
        public void CanCalculateTest()
        {
            Assert.AreEqual(true, isa.CanCalculate(null));
        }

        [TestMethod()]
        public void CalculateTest()
        {
            var mock = new Mock<IsaDevViewModel>();
            //mock.CallBase = true;
            var ta = mock.Object;
            ta.Calculate(null);
            ta.Altitude = 35000;
            ta.TemperatureC = 35;

            Assert.AreEqual(35000, ta.Altitude);
            Assert.AreEqual(35, ta.TemperatureC);

        }


    }
}