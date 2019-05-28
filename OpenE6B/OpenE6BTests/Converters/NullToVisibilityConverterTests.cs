using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OpenE6B.Converters.Tests
{
    [TestClass()]
    public class NullToVisibilityConverterTests
    {
        NullToVisibilityConverter nVC = new NullToVisibilityConverter();

        [TestMethod()]
        public void ConvertTest_Object_Is_Null()
        {
            // nVC.Convert(null, null, null, new System.Globalization.CultureInfo("en-us"));

            Assert.AreEqual(Visibility.Collapsed, nVC.Convert(null, null, null, new System.Globalization.CultureInfo("en-us")));
        }

        [TestMethod()]
        public void ConvertTest_Object_Not_Null()
        {
            // nVC.Convert(null, null, null, new System.Globalization.CultureInfo("en-us"));

            Assert.AreEqual(Visibility.Visible, nVC.Convert(0, null, null, new System.Globalization.CultureInfo("en-us")));
        }

        [TestMethod()]
        public void ConvertBackTest()
        {
            try
            {
                nVC.ConvertBack(null, null, null, null);
            }
            catch (NotImplementedException)
            {
                //  Expected exception caught!!!
                return;
            }
            Assert.Fail("Expected NotImplementedException not caught!");
        }
    }
}