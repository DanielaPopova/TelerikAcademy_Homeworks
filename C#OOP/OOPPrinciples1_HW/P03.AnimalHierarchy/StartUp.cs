﻿namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Animals;
    using Enumerations;

    public class StartUp
    {
        public static void Main()
        {
            // arrays of diff animals
            var dogList = new Dog[]
            {
                new Dog("Buck", 2.5, Gender.Male),
                new Dog("Sara", 5, Gender.Female),
                new Dog("Blacky", 6, Gender.Male),
                new Dog("Zara", 10, Gender.Female),
                new Dog("Sharo", 15, Gender.Male)
            };

            var frogList = new Frog[]
            {
                new Frog("Kermit", 1, Gender.Male),
                new Frog("Froggy", 2, Gender.Male),
                new Frog("Jana", 1.5, Gender.Female),
                new Frog("Lilla", 3, Gender.Female),
                new Frog("Presley", 2.5, Gender.Male) 
            };

            var catList = new Cat[]
            {
                new Tomcat("Tommy", 3),
                new Tomcat("Jimmy", 5.5),
                new Kitten("Rose", 4),
                new Tomcat("Sony", 4.5),
                new Kitten("Katty", 2)
            };

            double averageAgedogs = dogList
                .Sum(d => d.Age) / dogList.Length;

            Console.WriteLine("Average Age of Dogs: {0}", averageAgedogs);

            double averageAgeCats = catList
                .Sum(c => c.Age) / catList.Length;

            Console.WriteLine("Average Age of Cats: {0}", averageAgeCats);

            double averageAgeFrogs = frogList
                .Sum(fr => fr.Age) / frogList.Length;

            Console.WriteLine("Average Age of Frogs: {0}", averageAgeFrogs);

            var averageAgeAllAnimals = dogList
                .Concat<Animal>(catList)
                .Concat<Animal>(frogList)
                .Sum(al => al.Age) / (dogList.Length + catList.Length  + frogList.Length);

            Console.WriteLine("All animals average age / array: {0}", averageAgeAllAnimals); 
            
            // list of animals
            var animals = new List<Animal>
            {
                new Frog("Jim", 2, Gender.Male),
                new Dog("Doggy", 10, Gender.Male),
                new Kitten("Sarah", 5.5),
                new Tomcat("Donny", 4),
                new Dog("Willa", 12, Gender.Female)
            };

            double averageAnimal = animals
                .Average(an => an.Age);

            Console.WriteLine("All animals average age / list: {0}", averageAnimal);
        }
    }
}
