using System;
using System.Threading.Tasks;

namespace Nullable_references
{

    class Program
    {
        async static Task Main(string[] args)
        {
            var repository = new PersonRepository();

            var person = await repository.Get();

            // Null-coalescing Assignment
            person = null;

            InsertOrUpdate(person!);
        }

        static void InsertOrUpdate(Person person)
        {

            Console.WriteLine(person.Name.Length);
        }
    }

    class Person
    {
        public string? Name { get; set; }

        public Person()
        {
        }
    }

    class PersonRepository
    {
        public Task<Person> Get() => Task.FromResult((Person)null);
    }
}
