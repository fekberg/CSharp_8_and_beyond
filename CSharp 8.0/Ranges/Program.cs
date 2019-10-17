using System;

namespace Ranges
{
    class Program
    {
        static void Main(string[] args)
        {
            Span<int> data = new [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            #region Slice 5..^1

            var slice = data[5..^1]; // ^0 ?

            foreach (var number in slice)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            #endregion

            #region Range 1..4

            foreach (var number in data[1..^0])
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            #endregion

            #region Index ^5

            Index index = ^1; // ^0 ?

            Console.WriteLine(data[index]);
            Console.WriteLine();
            #endregion

            #region [first..last]
            var first = ^4;
            var last = ^1;
            foreach (var number in data[..])
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            #endregion
        }
    }
}
