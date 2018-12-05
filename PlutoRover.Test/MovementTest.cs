using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Test
{
    [TestClass]
    public class MovementTest
    {
        [TestMethod]
        public void TestSetup()
        {
            RoverPositionModule m = new RoverPositionModule(0, 0, Direction.North);

            Assert.AreEqual(0, m.xPos);
            Assert.AreEqual(0, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestForwardMovementVertical()
        {
            RoverPositionModule m = new RoverPositionModule(0, 5, Direction.North);

            m.MoveCommand("F");

            Assert.AreEqual(0, m.xPos);
            Assert.AreEqual(6, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestBackwardsMovementVertical()
        {
            RoverPositionModule m = new RoverPositionModule(0, 5, Direction.North);

            m.MoveCommand("B");

            Assert.AreEqual(0, m.xPos);
            Assert.AreEqual(4, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestForwardBackwardsMovementVertical()
        {
            RoverPositionModule m = new RoverPositionModule(0, 5, Direction.North);

            m.MoveCommand("FFBFFB");

            Assert.AreEqual(0, m.xPos);
            Assert.AreEqual(7, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestForwardMovementHorizontal()
        {
            RoverPositionModule m = new RoverPositionModule(5, 0, Direction.East);

            m.MoveCommand("F");

            Assert.AreEqual(0, m.xPos);
            Assert.AreEqual(6, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestBackwardsMovementHorizontal()
        {
            RoverPositionModule m = new RoverPositionModule(5, 0, Direction.East);

            m.MoveCommand("B");

            Assert.AreEqual(6, m.xPos);
            Assert.AreEqual(0, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestForwardBackwardsMovementHorizontal()
        {
            RoverPositionModule m = new RoverPositionModule(0, 5, Direction.East);

            m.MoveCommand("FFBFFB");

            Assert.AreEqual(0, m.xPos);
            Assert.AreEqual(7, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

    }
}
