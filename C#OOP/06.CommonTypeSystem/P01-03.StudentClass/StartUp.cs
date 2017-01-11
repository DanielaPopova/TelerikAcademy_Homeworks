namespace StudentClass
{
    using System;
    using System.Collections.Generic;
    using StudentClass.Enumerations;
    using StudentClass.Models;

    public class StartUp
    {
        public static void Main()
        {
            var mathStudent = new Student("Ivan", "Toshev", "Petkov", 456813496, "Sofia, Mladost", "0865123654", "i.i.petkov@abv.bg", 4, Specialty.AppliedMathematics, Faculty.MathematicsFaculty, University.SU);
            var lawStudent = new Student("Lila", "Lalova", "Lolova", 561323478, "Sofia, Obelia", "0888563211", "lilla@abv.bg", 3, Specialty.CivilLaw, Faculty.LawFaculty, University.SU);
            var itStudent = new Student("Peter", "Toshev", "Ivanov", 996541207, "Sofia, Liulin", "0875636365", "peshoI@gmail.com", 4, Specialty.SoftwareEngineering, Faculty.ComputerScienceAndTechnologyFaculty, University.SU);
            var chemStudent = new Student("Eva", "Hristova", "Roydeva", 558465892, "Sofia, Ovcha Kupel", "0889447100", "eva.roydeva@gmail.com", 5, Specialty.ChemicalEngineering, Faculty.EngineeringFaculty, University.UCTM);
            var busStudent = new Student("Stoian", "Dimitrov", "Kostov", 775698223, "Sofia, Drujba", "0884654445", "stokos@abv.bg", 1, Specialty.BusinessAdministration, Faculty.BusinessAndManagementFaculty, University.UNWE);

            // ToString()
            Console.WriteLine(mathStudent);
            Console.WriteLine(chemStudent);

            // Equals()
            Console.WriteLine("\nTesting Equals()");

            if (mathStudent.MiddleName == itStudent.MiddleName)
            {
                Console.WriteLine($"{mathStudent.FirstName} and {itStudent.FirstName} have the same middle name - {mathStudent.MiddleName}");
            }
            else
            {
                Console.WriteLine($"{mathStudent.FirstName} and {itStudent.FirstName} don't the same middle name!");
                Console.WriteLine($"{mathStudent.FirstName}: {mathStudent.MiddleName}\n{itStudent.FirstName}: {itStudent.MiddleName}");

            }

            if (chemStudent.SocialSecurityNumber == busStudent.SocialSecurityNumber)
            {
                Console.WriteLine($"{chemStudent.FirstName} and {busStudent.FirstName} have the same social security number - {chemStudent.SocialSecurityNumber}");
            }
            else
            {
                Console.WriteLine($"{chemStudent.FirstName} and {busStudent.FirstName} dont't have the same social security number!");
                Console.WriteLine($"{chemStudent.FirstName}: {chemStudent.SocialSecurityNumber}\n{busStudent.FirstName}: {busStudent.SocialSecurityNumber}");
            }

            // GetHashCode()
            Console.WriteLine("\nTesting GetHashCode()");
            Console.WriteLine(mathStudent.MiddleName.GetHashCode());
            Console.WriteLine(itStudent.MiddleName.GetHashCode());

            Console.WriteLine(lawStudent.SocialSecurityNumber.GetHashCode());
            Console.WriteLine(busStudent.SocialSecurityNumber.GetHashCode());

            // Clone()
            Console.WriteLine("\nTesting Clone()");
            Student newItStudentWithClone = (Student)itStudent.Clone();
            newItStudentWithClone.FirstName = "Stoian";
            Console.WriteLine(newItStudentWithClone.FirstName.CompareTo(itStudent.FirstName) == 0 ? "names are equal - clone NOT successful!" : "names are not equal - successful clone!");
            Console.WriteLine($"Clone: {newItStudentWithClone.FirstName} --- Original: {itStudent.FirstName}");

            Student newItStudentWithoutClone = itStudent;
            newItStudentWithoutClone.FirstName = "Alex";
            Console.WriteLine(newItStudentWithoutClone.FirstName.CompareTo(itStudent.FirstName) == 0 ? "names are equal - clone NOT successful!" : "names are not equal - successful clone!");
            Console.WriteLine($"Clone: {newItStudentWithoutClone.FirstName} --- Original: {itStudent.FirstName}");

            // CompareTo()
            Console.WriteLine("\nTesting CompareTo()");
            
            var students = new Student[] 
            {
                new Student("Ivan", "Toshev", "Petkov", 456813496),
                new Student("Lila", "Lalova", "Lolova", 561323478),
                new Student("Ivan", "Toshev", "Ivanov", 996541207),
                new Student("Eva", "Hristova", "Roydeva", 558465892),
                new Student("Georgi", "Plamenov", "Titov", 663457986),
                new Student("Eva", "Hristova", "Roydeva", 654987123),
                new Student("Stoian", "Dimitrov", "Kostov", 775698223),
                new Student("Stoian", "Kamenov", "Popov", 665998420)

            };

            Array.Sort(students);
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.MiddleName + " " + student.LastName + " " + student.SocialSecurityNumber);
            }
        }        
    }
}
