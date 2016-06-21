namespace StartProgram
{
    using System;
    using System.Collections.Generic;   
    using Schools.SchoolModel;
    using Schools.People;
    using Schools.Disciplines;
    using Schools.Interfaces;

    public class Start_P01School
    {
        public static void Main()
        {
            var firstStudent = new Student("Peter Ivanov", 15);
            var secondStudent = new Student("Lili Dimova", 14);
            var thirdStudent = new Student("Ivan Geshev", 13);            

            var mathTeacher = new Teacher("Stoian Popov");
            mathTeacher.AddDiscipline(new Discipline(DisciplineName.Mathematics, 4, 8));
            mathTeacher.AddDiscipline(new Discipline(DisciplineName.Physics, 2, 2));

            var bgTeacher = new Teacher("Leda Simova");
            bgTeacher.AddDiscipline(new Discipline(DisciplineName.Literature, 5, 8));
            bgTeacher.AddDiscipline(new Discipline(DisciplineName.BulgarianLanguage, 5, 8));

            var classA = new SchoolClass("12a");
            classA.AddStudent(firstStudent);
            classA.AddStudent(secondStudent);
            classA.AddStudent(thirdStudent);
            classA.Addteacher(mathTeacher);
            classA.Addteacher(bgTeacher);

            Console.WriteLine(classA.PrintClassInfo());
            Console.WriteLine(new string('-', 50));

            var daniStudent = new Student("Daniela Ilieva", 7);
            var georgeStudent = new Student("Georgi Topalov", 5);

            var artsTeacher = new Teacher("Eva Gerova");
            artsTeacher.AddDiscipline(new Discipline(DisciplineName.FineArts, 2, 3));

            var historyTeacher = new Teacher("Sasho Mihov");
            historyTeacher.AddDiscipline(new Discipline(DisciplineName.History, 3, 4));

            var classB = new SchoolClass("12b");
            classB.AddStudent(daniStudent);
            classB.AddStudent(georgeStudent);
            classB.Addteacher(artsTeacher);
            classB.Addteacher(historyTeacher);

            Console.WriteLine(classB.PrintClassInfo());
            Console.WriteLine(new string('-', 50));

            var school = new School();
            school.AddClass(classA);
            school.AddClass(classB);
            Console.WriteLine(school.PrintSchoolInfo());
        }
    }
}
