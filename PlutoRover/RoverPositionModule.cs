using System;

namespace PlutoRover
{
    public class RoverPositionModule
    {
        public int xPos { get; private set; } 
        public int yPos { get; private set; }
        public Direction direction { get; private set; }
        public bool HitObstacle { get; private set; }

        public RoverPositionModule(int x, int y, Direction direction)
        {
            xPos = x;
            yPos = y;
            this.direction = direction;
        }

        public void MoveCommand(string movementString)
        {
            foreach (char command in movementString)
            {
                switch (command)
                {
                    case 'F':
                        Move(1);
                        break;
                    case 'B':
                        Move(-1);
                        break;
                    case 'R':
                        Rotate(1);
                        break;
                    case 'L':
                        Rotate(-1);
                        break;
                    default:
                        throw new Exception($"Unknown command {command}");
                }
            }
        }

        private void Move(int numberOfPlaces)
        {
            if (direction == Direction.South || direction == Direction.West)
                numberOfPlaces = -numberOfPlaces;

            int xLimit = WorldConstants.xMax + 1; 
            if (direction == Direction.North || direction == Direction.South)
                yPos = (yPos + numberOfPlaces + xLimit) % xLimit;

            int yLimit = WorldConstants.yMax + 1;
            if (direction == Direction.East || direction == Direction.West)
                xPos = (xPos + numberOfPlaces + yLimit) % yLimit;
        }

        private void Rotate(int numberOfClockwiseRightAngles)
        {
            int directionInt = (int)direction;
            directionInt = (directionInt + 4 + numberOfClockwiseRightAngles) % 4;
            direction = (Direction)directionInt;
        }
    }
}
