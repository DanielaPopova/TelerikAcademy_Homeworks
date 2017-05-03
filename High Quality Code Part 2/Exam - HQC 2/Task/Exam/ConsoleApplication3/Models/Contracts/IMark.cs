namespace SchoolSystem.Models.Contracts
{
    using SchoolSystem.Enums;

    public interface IMark
    {
        Subject Subject { get; }

        float Value { get; }
    }
}
