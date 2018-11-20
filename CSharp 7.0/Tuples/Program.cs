﻿using static System.Console;

namespace Tuples
{
    class Program
    {
        public static (int x, int y) GetPoint()
        {
            return (100, 200);
        }

        static void Main(string[] args)
        {
            #region Tuples & Deconstruction

            (int x, int y) point = GetPoint();

            WriteLine($"{nameof(point.x)} : {point.x}");
            WriteLine($"{nameof(point.y)} : {point.y}");

            #endregion

            #region Deconstruction 2

            (int x1, int y1) = GetPoint();

            WriteLine($"{nameof(x1)} : {x1}");
            WriteLine($"{nameof(y1)} : {y1}");

            #endregion

            #region Deconstruction 3

            var (x2, y2) = GetPoint();

            WriteLine($"{nameof(x2)} : {x2}");
            WriteLine($"{nameof(y2)} : {y2}");

            #endregion
        }
    }
}
