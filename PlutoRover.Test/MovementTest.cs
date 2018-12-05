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

        #region straight movement
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
        #endregion straight movement

        #region Rotational movement
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
        #endregion Rotational movement

        #region Wrapping        
        [TestMethod]
        public void TestWrapNorthForward()
        {
            RoverPositionModule m = new RoverPositionModule(95, 95, Direction.North);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(95, m.xPos);
            Assert.AreEqual(4, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestWrapNorthBackward()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.North);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(5, m.xPos);
            Assert.AreEqual(96, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }

        [TestMethod]
        public void TestWrapEastForward()
        {
            RoverPositionModule m = new RoverPositionModule(95, 95, Direction.East);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(4, m.xPos);
            Assert.AreEqual(95, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestWrapEastBackward()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.East);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(96, m.xPos);
            Assert.AreEqual(5, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
        }

        [TestMethod]
        public void TestWrapSouthForward()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.South);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(5, m.xPos);
            Assert.AreEqual(96, m.yPos);
            Assert.AreEqual(Direction.South, m.direction);
        }

        [TestMethod]
        public void TestWrapSouthBackward()
        {
            RoverPositionModule m = new RoverPositionModule(95, 95, Direction.South);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(95, m.xPos);
            Assert.AreEqual(4, m.yPos);
            Assert.AreEqual(Direction.South, m.direction);
        }

        [TestMethod]
        public void TestWrapWestForward()
        {
            RoverPositionModule m = new RoverPositionModule(5, 5, Direction.West);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(96, m.xPos);
            Assert.AreEqual(5, m.yPos);
            Assert.AreEqual(Direction.West, m.direction);

        }

        [TestMethod]
        public void TestWrapWestBackward()
        {
            RoverPositionModule m = new RoverPositionModule(95, 95, Direction.West);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(4, m.xPos);
            Assert.AreEqual(95, m.yPos);
            Assert.AreEqual(Direction.West, m.direction);
        }

        [TestMethod]
        public void TestWrappingRoundRoute()
        {
            RoverPositionModule m = new RoverPositionModule(95, 95, Direction.North);

            m.MoveCommand("FFFFFFFFFFRFFFFFFFFFFRFFFFFFFFFFRFFFFFFFFFFR");

            Assert.AreEqual(95, m.xPos);
            Assert.AreEqual(95, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
        }
        #endregion Wrapping

        #region Obstacle Detection
        [TestMethod]
        public void TestHitNorth()
        {
            RoverPositionModule m = new RoverPositionModule(13, 10, Direction.North);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(13, m.xPos);
            Assert.AreEqual(12, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitNorthBackWard()
        {
            RoverPositionModule m = new RoverPositionModule(13, 10, Direction.South);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(13, m.xPos);
            Assert.AreEqual(12, m.yPos);
            Assert.AreEqual(Direction.South, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitEast()
        {
            RoverPositionModule m = new RoverPositionModule(10, 13, Direction.East);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(13, m.xPos);
            Assert.AreEqual(12, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitEastBackWard()
        {
            RoverPositionModule m = new RoverPositionModule(10, 13, Direction.West);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(13, m.xPos);
            Assert.AreEqual(12, m.yPos);
            Assert.AreEqual(Direction.West, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitSouth()
        {
            RoverPositionModule m = new RoverPositionModule(13, 15, Direction.South);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(15, m.xPos);
            Assert.AreEqual(14, m.yPos);
            Assert.AreEqual(Direction.South, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitSouthBackwards()
        {
            RoverPositionModule m = new RoverPositionModule(13, 15, Direction.North);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(15, m.xPos);
            Assert.AreEqual(14, m.yPos);
            Assert.AreEqual(Direction.North, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitWest()
        {
            RoverPositionModule m = new RoverPositionModule(15, 13, Direction.West);

            m.MoveCommand("FFFFFFFFFF");

            Assert.AreEqual(14, m.xPos);
            Assert.AreEqual(13, m.yPos);
            Assert.AreEqual(Direction.West, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }

        [TestMethod]
        public void TestHitWestBackward()
        {
            RoverPositionModule m = new RoverPositionModule(15, 13, Direction.East);

            m.MoveCommand("BBBBBBBBBB");

            Assert.AreEqual(14, m.xPos);
            Assert.AreEqual(13, m.yPos);
            Assert.AreEqual(Direction.East, m.direction);
            Assert.AreEqual(true, m.HitObstacle);
        }
        #endregion Obstacle Detection
    }
}
