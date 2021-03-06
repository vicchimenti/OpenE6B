﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void AsyncCmdBaseExecuteTest()
        {   
            var mock = new Mock<AsyncCommandBase>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.Execute(null);
            mock.Setup(m => m.Execute(null)).Verifiable();
            mock.Verify(m => m.Execute(null), Times.Once());         

        }

        //[TestMethod()]
        //public void AsyncCmdBaseCanExecuteChangedTest()
        //{
        //    var mock = new Mock<AsyncCommandBase>();
        //    mock.CallBase = true;
        //    var ta = mock.Object;
            
        //    ta.CanExecuteChanged()
        //    mock.Setup(m => m.Execute(null)).Verifiable();
        //    mock.Verify(m => m.Execute(null), Times.Once());

        //}

        [TestMethod()]
        public void AsyncCmdBaseCanExecuteTest()
        {
            var mock = new Mock<AsyncCommandBase>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.CanExecute(null);
            mock.Verify(m => m.CanExecute(null), Times.Once());

        }

        [TestMethod()]
        public void AsyncCmdBaseCanExecuteAsyncTest()
        {
            var mock = new Mock<AsyncCommandBase>();
            mock.CallBase = true;
            var ta = mock.Object;
            ta.ExecuteAsync(null);
            mock.Verify(m => m.ExecuteAsync(null), Times.Once());

        }

    }
}