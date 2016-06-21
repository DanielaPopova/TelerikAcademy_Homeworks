namespace AnimalHierarchy.Animals
{
    using AnimalHierarchy.Enumerations;
    using AnimalHierarchy.Interfaces;

    public class Cat : Animal
    {
        public Cat(string name, double age, Gender gender) : base(name, age, gender)
        {
        }
    }
}
