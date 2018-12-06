using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover
{
    public class WorldConstants
    {
        public static int xMax { get; private set; } = 100;
        public static int yMax { get; private set; } = 100;

        public static List<int[]> obstacles { get; private set; } = new List<int[]>();


        static WorldConstants()
        {
            obstacles.Add(new int[] { 10, 10 });
            obstacles.Add(new int[] { 11, 11 });
            obstacles.Add(new int[] { 12, 12 });
            obstacles.Add(new int[] { 13, 13 });
            obstacles.Add(new int[] { 14, 14 });
            obstacles.Add(new int[] { 15, 15 });
        }
    }
}
