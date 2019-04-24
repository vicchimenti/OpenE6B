using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OpenE6B.Validators.Tests
{
    [TestClass()]
    public class StringToStationValidationRuleTests
    {
        StringToStationValidationRule station = new StringToStationValidationRule();

        [TestMethod()]
        public void ValidateStationNamePositiveTest()
        {
            // Test with a valid station name
            Assert.AreEqual(new ValidationResult(true, ""), station.Validate("ksea", new System.Globalization.CultureInfo("en-us")));
        }

        [TestMethod()]
        public void ValidateStationNameMustBeFourCharactersLongTest()
        {
            // A station name must be exaclty 4 characters long
            Assert.AreNotEqual(new ValidationResult(true, ""), station.Validate("Kse", new System.Globalization.CultureInfo("en-us")));
        }

        [TestMethod()]
        public void ValidateStationNameMustBeLettersOnlyTest()
        {
            // A station name must be comprosided of letters only
            Assert.AreNotEqual(new ValidationResult(true, ""), station.Validate("Kse0", new System.Globalization.CultureInfo("en-us")));
        }

        [TestMethod()]
        public void ValidateStationNameEmptyStringTest()
        {
            // A station name must be comprosided of letters only
            Assert.AreNotEqual(new ValidationResult(true, ""), station.Validate("", new System.Globalization.CultureInfo("en-us")));
        }
    }
}