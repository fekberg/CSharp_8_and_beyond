using System;

namespace Default_interface_methods
{

    class Program
    {
        static void Main(string[] args)
        {
            // ICache cache = new InMemoryCache();
            ICache cache = new InMemoryCache();
            
            cache.Add("1", "Hello world");
            cache.Add("2", 123);
            cache.Get<int>("1");

            Console.WriteLine(cache.Get("1"));
        }
    }
}
