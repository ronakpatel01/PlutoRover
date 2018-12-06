using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover
{
    public class ObstacleDetectionModule
    {
        public static bool IsObstacle(int x, int y)
        {
            foreach (int[] obstacle in WorldConstants.obstacles)
                if (obstacle[0] == x && obstacle[1] == y)
                    return true;

            return false;
        }
    }
}
