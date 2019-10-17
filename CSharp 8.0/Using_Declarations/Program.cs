using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Using_Declarations
{
    class Program
    {
        //static async Task Main(string[] args)
        //{
        //    using var client = new HttpClient();

        //    await client.GetAsync("https://fekberg.com");

        //    await client.GetAsync("https://ndcsydney.com");
        //}

        #region Example from @reubenbond
        static void Main(string[] args)
        {
            using var _ = new Defer(() => Console.WriteLine("from Filip!"));

            Console.WriteLine("Hello NDC!");
        }

        struct Defer : IDisposable
        {
            private Action Action { get; }

            public Defer(Action action) => Action = action;

            public void Dispose() => Action?.Invoke();
        }
        #endregion
    }
}
