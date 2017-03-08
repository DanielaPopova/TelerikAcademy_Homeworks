namespace People
{
    using System;

    using People.Models;

    public class StartUp
    {
        public static void Main()
        {
            var person = new Person().MakePerson(16);
           
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Gender: {person.Gender}");
        }
    }
}
