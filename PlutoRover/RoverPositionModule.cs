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
                    default:
                        throw new Exception($"Unknown command {command}");
                }
            }
        }

        private void Move(int numberOfPlaces)
        {
            if (direction == Direction.South || direction == Direction.West)
                numberOfPlaces = -numberOfPlaces;

            if (direction == Direction.North || direction == Direction.South)
                yPos += numberOfPlaces;

            if (direction == Direction.East || direction == Direction.West)
                xPos += numberOfPlaces;
        }
    }
}
