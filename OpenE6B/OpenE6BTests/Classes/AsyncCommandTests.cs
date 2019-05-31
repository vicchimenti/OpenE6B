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
    public class AsyncCommandTests
    {
        [TestMethod()]
        public void ExecuteAsyncTest()
        {
            var mock = new Mock<IAsyncCommand>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.ExecuteAsync(null);
            mock.Verify(m => m.ExecuteAsync(null), Times.Once());
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            var mock = new Mock<IAsyncCommand>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.Execute(null);
            mock.Verify(m => m.Execute(null), Times.Once());
        }

        [TestMethod()]
        public void CanExecuteTest()
        {
            var mock = new Mock<IAsyncCommand>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.ExecuteAsync(null);
            mock.Setup(m => m.CanExecute(null)).Returns(true);
            mock.Verify(m => m.ExecuteAsync(null), Times.Once());
        }

    }
}