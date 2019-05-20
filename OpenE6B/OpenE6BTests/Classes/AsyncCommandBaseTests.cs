using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenE6B.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

namespace OpenE6B.Classes.Tests
{
    [TestClass()]
    public class AsyncCommandBaseTests
    {
        // AsyncCommandBase acb = new AsyncCommandBase();

        [TestMethod()]
        public void ExecuteTest()
        {   
            var mock = new Mock<AsyncCommandBase>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.Execute(null);
            mock.Verify(m => m.Execute(null), Times.Once());         

        }

    }
}