using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Async_Streams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await foreach (var data in Get())
            //{
            //    Console.WriteLine(data);
            //}

            #region Lyrics
            
            await foreach (var line in GetLyrics())
            {
                Console.WriteLine(line);
            }
            #endregion
        }

        #region Completed
        public static async IAsyncEnumerable<int> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(300);

                yield return i;
            }
        }

        public static async IAsyncEnumerable<string> GetLyrics()
        {
            using var stream = new StreamReader(@"C:\Code\lyrics.txt");

            string line;
            while ((line = await stream.ReadLineAsync()) != null)
            {
                await Task.Delay(400);

                yield return line;
            }
        }
        #endregion
    }
}
