namespace JsonRepo.api.Models;

public class Person
{
    public Person(string name, DateTime bornDate, string email)
    {
        Name = name;
        BornDate = bornDate;
        Email = email;
    }

    [JsonConstructor]
    public Person(long id, string name, DateTime bornDate, string email)
    {
        Id = id;
        Name = name;
        BornDate = bornDate;
        Email = email;
    }

    public long Id { get; private set; }
    public string Name { get; private set; }
    public DateTime BornDate { get; private set; }
    public string Email { get; private set; }
}
