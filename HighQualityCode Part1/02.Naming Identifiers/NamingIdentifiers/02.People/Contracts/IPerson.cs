namespace People.Contracts
{
    using People.Enums;

    public interface IPerson
    {
        string Name { get; set; }

        int Age { get; set; }

        GenderType Gender { get; set; }

        IPerson MakePerson(int age);
    }
}
