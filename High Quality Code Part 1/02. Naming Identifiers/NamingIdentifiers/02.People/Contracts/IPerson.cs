namespace People.Contracts
{
    using People.Enums;

    public interface IPerson
    {
        string Name { get; set; }

        long EGN { get; set; }

        GenderType Gender { get; set; }        
    }
}
