namespace ConsoleStartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SchoolSystem.Models;    

    public class StartUp
    {
        public static void Main()
        {
            //testing Schoolsystem classes
            var sou7 = new School("7mo SOU");

            var oop = new Course("C# OOP");
            var js = new Course("javascript");

            var ivan = new Student("Ivan", 10000);
            var pesho = new Student("Pesho", 66958);
            var dima = new Student("Dima", 55666);
            var angel = new Student("Angel", 25469);
            var rosi = new Student("Rosi", 10022);

            sou7.AddCourse(oop);
            sou7.AddCourse(js);

            sou7.AdmitStudent(pesho);

            Console.WriteLine(sou7);
        }
    }
}
