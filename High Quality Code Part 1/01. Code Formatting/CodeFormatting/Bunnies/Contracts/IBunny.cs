namespace Bunnies.Contracts
{
    using Bunnies.Enums;

    public interface IBunny
    {
        string Name { get; set; }

        int Age { get; set; }

        FurType FurType { get; set; }

        void Introduce(IWriter writer);
    }
}
