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

            Assert.AreEqual(6, m.xPos);
            Assert.AreEqual(0, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestBackwardsMovementHorizontal()
        {
            RoverPositionModule m = new RoverPositionModule(5, 0, Direction.East);

            m.MoveCommand("B");

            Assert.AreEqual(4, m.xPos);
            Assert.AreEqual(0, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestForwardBackwardsMovementHorizontal()
        {
            RoverPositionModule m = new RoverPositionModule(5, 0, Direction.East);

            m.MoveCommand("FFBFFB");

            Assert.AreEqual(7, m.xPos);
            Assert.AreEqual(0, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestRotateClockwise()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.North);

            m.MoveCommand("R");

            Assert.AreEqual(5, m.xPos);
            Assert.AreEqual(5, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestRotateAntiClockwise()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.North);

            m.MoveCommand("L");

            Assert.AreEqual(5, m.xPos);
            Assert.AreEqual(5, m.yPos);
            Assert.AreEqual(Direction.West, m.direction);
        }

        [TestMethod]
        public void TestRoundTripClockwise()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.North);

            m.MoveCommand("FFRFFRFFRFFR");

            Assert.AreEqual(5, m.xPos);
            Assert.AreEqual(5, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestRoundTripAntiClockwise()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.North);

            m.MoveCommand("FFLFFLFFLFFL");

            Assert.AreEqual(5, m.xPos);
            Assert.AreEqual(5, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestSnakeMovement()
        {
            RoverPositionModule m = new RoverPositionModule(2, 2, Direction.North);

            m.MoveCommand("FFRFLFFLFRFFRF");

            Assert.AreEqual(3, m.xPos);
            Assert.AreEqual(8, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }
    }
}
