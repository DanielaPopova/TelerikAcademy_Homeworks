namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StudentsAndWorkers.Models;

    public class StartUp
    {
        public static void Main()
        {
            // students
            var students = new List<Student>
            {
                new Student("Dimityr", "Ivanov", 6.00),
                new Student("Ivan", "Geshov", 5.50),
                new Student("Galia", "Mancheva", 5.50),
                new Student("Stefan", "Petkov", 4.50),
                new Student("Valentin", "Hristov", 3.50),
                new Student("Georgi", "Kostov", 5.00),
                new Student("Peter", "Kirov", 2.00),
                new Student("Ivan", "Bakalov", 4.00),
                new Student("Ani", "Tencheva", 6.00),
                new Student("Dimo", "Lalev", 3.00)
            };

            var orderedByNameStudents = students
                .OrderBy(st => st.Grade);

            foreach (var student in orderedByNameStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('-', 50));

            // workers
            var workers = new List<Worker>
            {
                new Worker("Georgi", "Kirilov", 200, 5.5),
                new Worker("Svilen", "Petkov", 250, 8.0),
                new Worker("Borislav", "Shopov", 240, 6.0),
                new Worker("Anelia", "Stoianova", 400, 12.0),
                new Worker("Mihail", "Mihov", 320, 10.0),
                new Worker("Nikola", "Peshev", 180, 4.0),
                new Worker("Cvetelina", "Dimova", 520, 16.0),
                new Worker("Vania", "Popova", 350, 7.0),
                new Worker("Denitsa", "Dimitrova", 240, 8.0),
                new Worker("Rado", "Mirchev", 270, 5.5)
            };

            var orderedByMoneyWorkers = workers
                .OrderByDescending(w => w.MoneyPerHour());

            foreach (var worker in orderedByMoneyWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine(new string('-', 50));

            // merge both students and workers
            var mergedList = students
                .Concat<Human>(workers)
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName);

            foreach (var human in mergedList)
            {
                Console.WriteLine(human.FirstName + " " + human.LastName);
            }
        }
    }
}
