namespace AnimalHierarchy.Models
{
    using AnimalHierarchy.Enumerations;

    public class Tomcat : Cat
    {
        public Tomcat(string name, double age)
            : base(name, age, GenderType.Male)
        {            
        }

        public override string MakeSound()
        {
            return "Meow, meow!";
        }
    }
}
