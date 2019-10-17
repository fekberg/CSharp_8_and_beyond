using System;

namespace Null_coalescing_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Person filip = null;

            filip = filip ?? new Person { Name = "Filip" }; // ??=

            Console.WriteLine(filip.Name);
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
