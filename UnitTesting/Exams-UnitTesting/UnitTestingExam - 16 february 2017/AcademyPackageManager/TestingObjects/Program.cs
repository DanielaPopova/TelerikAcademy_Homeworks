using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingObjects
{
    public class Status
    {
        public Status(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; private set; }
    }

    public class Person
    {
        public Person(string sex, Status status)
        {
            this.Sex = sex;
            this.Status = status;
        }

        public string Sex { get; set; }

        public Status Status { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Sex, this.Status.Name, this.Status.Age);
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            var male = new Person("male", new Status("ivan", 25));
            var otherMale = new Person("male", new Status("pesho", 30));

            Console.WriteLine(male);
            Console.WriteLine(otherMale);

            otherMale.Status = male.Status;

            Console.WriteLine(new string('=', 30));

            Console.WriteLine(otherMale);
        }
    }
}
