namespace People
{
    using System;

    using People.Models;

    public class StartUp
    {
        public static void Main()
        {            
            var personFactory = new PersonFactory();
            var person = personFactory.CreatePerson(8805257188);

            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Gender: {person.Gender}");
        }
    }
}
