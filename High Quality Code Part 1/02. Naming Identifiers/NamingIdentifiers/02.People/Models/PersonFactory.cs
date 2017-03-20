namespace People.Models
{
    using Contracts;
    using Enums;

    public class PersonFactory
    {
        public IPerson CreatePerson(long egn)
        {
            IPerson person = new Person();
            person.EGN = egn;

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
