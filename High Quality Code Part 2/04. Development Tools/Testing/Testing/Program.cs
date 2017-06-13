using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class startUp
    {
        static void Main(string[] args)
        {
            var student = new Student();

            Console.WriteLine(student.Age);

        }
    }

    public abstract class Person
    {
        private string firstName;
        private int age;

        public Person()
        {

        }

        public string FirstName { get; set; }

        public int Age { get; set; }
    }

    public class Student : Person
    {
        public Student() : base()
        {

        }

        public override string ToString()
        {
            return this.FirstName + " " + this.Age;
        }
    }


}
