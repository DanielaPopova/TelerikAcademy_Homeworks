namespace AnimalHierarchy.Models
{
    using AnimalHierarchy.Enumerations;

    public abstract class Cat : Animal
    {
        public Cat(string name, double age, GenderType gender)
            : base(name, age, gender)
        {

        }       
    }
}