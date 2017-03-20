namespace People.Models
{
    using System;

    using Contracts;
    using Enums;

    public class PersonFactory
    {
        public IPerson CreatePerson(long egn)
        {            
            int yearOfBirth = int.Parse("19" + egn.ToString().Substring(0, 2));
            IPerson person = new Person();
            person.Age = DateTime.Now.Year - yearOfBirth;

            if (egn % 2 == 0)
            {                
                person.Name = "Mitko";
                person.Gender = GenderType.Male;
            }
            else
            {
                person.Name = "Maria";
                person.Gender = GenderType.Female;
            }

            return person;
        }
    }
}
