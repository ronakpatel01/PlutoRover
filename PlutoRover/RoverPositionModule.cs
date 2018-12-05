using System;

namespace PlutoRover
{
    public class RoverPositionModule
    {
        public int xPos { get; private set; }
        public int yPos { get; private set; }
        public Direction direction { get; private set; }

        public RoverPositionModule(int x, int y, Direction direction)
        {
            xPos = x;
            yPos = y;
            this.direction = direction;
        }

        public void MoveCommand(string movementString)
        {

        }
    }
}
