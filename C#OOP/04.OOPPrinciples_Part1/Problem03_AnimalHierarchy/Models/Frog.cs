namespace AnimalHierarchy.Models
{
    using AnimalHierarchy.Enumerations;

    public class Frog : Animal
    {
        public Frog(string name, double age, GenderType gender)
            : base(name, age, gender)
        {
        }

        public override string MakeSound()
        {
            return "Qua qua!";
        }
    }
}
