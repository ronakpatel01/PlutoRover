using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Test
{
    [TestClass]
    public class MovementTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Test initial setup is working
            Movement m = new Movement();

            Assert.AreEqual(1, 1);
        }
    }
}
