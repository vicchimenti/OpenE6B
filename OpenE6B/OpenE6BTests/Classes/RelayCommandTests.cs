using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.Classes;
using OpenE6B.ViewModels;
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
        [TestMethod()]
        public void RelayCommandNullActionTest()
        {

            try
            {
                RelayCommand rc = new RelayCommand(null);
            }
            catch (NotImplementedException e)
            {
                // Expected exception caught!!!
                Assert.AreEqual("Not implemented", e.Message);
            }

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
                //  No exception is expected as it is swallowed.
                Assert.Fail("NotImplementedException not expected!");
            }

        }


        [TestMethod()]
        public void RelayCmdExecuteTest()
        {
            try
            {
                RelayCommand rc = new RelayCommand(null, null);
                rc.Execute(null);
            }
            catch (Exception e)
            {
                //  expected Exception caught!
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
                //return;
            }

        }

        [TestMethod()]
        public void RelayCmdCanExecuteTest()
        {
            RelayCommand rc = new RelayCommand(null, null);
          
            Assert.AreEqual(true, rc.CanExecute(null));
        }

        [TestMethod()]
        public void RelayCmdInvalidCanExecuteTest()
        {
            RelayCommand rc = new RelayCommand(null, null);
            var privateObject = new PrivateObject(rc);
 
            Assert.AreEqual(null, privateObject.Invoke("InvalidateCanExecute"));
        }
    }
    }