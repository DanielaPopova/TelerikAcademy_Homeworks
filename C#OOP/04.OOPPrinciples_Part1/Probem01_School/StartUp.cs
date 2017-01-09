namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    using SchoolSystem.Enumerations;
    using SchoolSystem.Models;

    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            var ivancho = new Student("Ivan Binev", 7);
            var pepi = new Student("Peter Stanev", 8);
            var daniela = new Student("Daniela Ilieva", 5);
            var stoyan = new Student("Stoyan Hristov", 12);
            var mirela = new Student("Mirela Karova", 15);

            var students = new List<Student>() { ivancho, pepi, daniela, stoyan, mirela };

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            var math = new Discipline(DisciplineType.Mathematics, 5, 30);
            var literature = new Discipline(DisciplineType.Literature, 6, 20);
            var chemistry = new Discipline(DisciplineType.Chemistry, 3, 20);
            var music = new Discipline(DisciplineType.Music, 1, 3);
            var sports = new Discipline(DisciplineType.PhysicalEducation, 2, 10);

            var disciplines = new List<Discipline> { math, literature, chemistry, music, sports };

            foreach (var discipline in disciplines)
            {
                Console.WriteLine(discipline);
            }

            var teacherGenov = new Teacher("Ivan Genov");
            var teacherPeshev = new Teacher("Dimityr Peshev");

            teacherGenov.AddDiscipline(math);
            teacherGenov.AddDiscipline(sports);

            teacherGenov.PrintDisciplines();

            teacherPeshev.AddDiscipline(chemistry);
            teacherPeshev.AddDiscipline(music);

            var class6a = new SchoolClass("6a");
            class6a.AddTeacher(teacherPeshev);           
            class6a.AddStudent(pepi);
            class6a.AddStudent(mirela);
            class6a.AddStudent(daniela);

            var class10b = new SchoolClass("10b");           
            class10b.AddTeacher(teacherGenov);
            class10b.AddStudent(ivancho);
            class10b.AddStudent(stoyan);            

            Console.WriteLine(class6a.PrintClassInfo());
            Console.WriteLine(class10b.PrintClassInfo());

            var school7SOU = new School("7-mo SOU");
            school7SOU.AddClass(class10b);
            Console.WriteLine(school7SOU.PrintSchoolInfo());
        }
    }
}
