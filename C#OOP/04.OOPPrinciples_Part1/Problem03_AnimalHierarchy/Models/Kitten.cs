namespace AnimalHierarchy.Models
{
    using AnimalHierarchy.Enumerations;

    public class Kitten : Cat
    {
        public Kitten(string name, double age)
            : base(name, age, GenderType.Female)
        {
        }

        public override string MakeSound()
        {
            return "Mrrr, mrrr!";
        }
    }
}
