namespace People.Models
{    
    using Contracts;
    using Enums;

    public class Person : IPerson
    {
        public string Name { get; set; }

        public long EGN { get; set; }

        public GenderType Gender { get; set; }       
    }
}
