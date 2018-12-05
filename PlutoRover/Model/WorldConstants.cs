using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover
{
    public class WorldConstants
    {
        public static int xMax { get; } = 100;
        public static int yMax { get; } = 100;

        public static int[,] obstacles = { { 10, 10 }, { 11, 11 }, { 13, 13 }, { 14, 14 }, { 15, 15 } };
    }
}
