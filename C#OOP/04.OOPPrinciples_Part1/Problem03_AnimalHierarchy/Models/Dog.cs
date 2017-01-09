namespace AnimalHierarchy.Models
{
    using AnimalHierarchy.Enumerations;

    public class Dog : Animal
    {
        public Dog(string name, double age, GenderType gender)
            : base(name, age, gender)
        {
        }

        public override string MakeSound()
        {
            return "Djaff, djaff!";
        }
    }
}
