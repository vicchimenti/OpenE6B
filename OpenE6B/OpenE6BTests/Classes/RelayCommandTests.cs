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
    public class RelayCommandTests
    {
        // RelayCommand rc = new RelayCommand(null);
        [TestMethod()]
        public void RelayCommandNullActionTest()
        {

            try
            {
                RelayCommand rc = new RelayCommand(null);
            }
            catch (NotImplementedException)
            {
                //  Expected exception caught!!!
                return;
            }

            Assert.Fail("Expected NotImplementedException not caught!");

        }

        [TestMethod()]
        public void RelayCommandNullActionNullPredicateTest()
        {

            try
            {
                RelayCommand rc = new RelayCommand(null, null);
            }
            catch (NotImplementedException)
            {
                //  No exception is expected as it is swalloed.
                Assert.Fail("NotImplementedException not expected!");
            }

            //Assert.That

        }


        //[TestMethod()]
        //public void RelayCommandTest1()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ExecuteTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void CanExecuteTest()
        //{
        //    Assert.Fail();
        //}
    }
}