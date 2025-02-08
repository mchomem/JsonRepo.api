namespace JsonRepo.api.DTOs;

public class PersonDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BornDate { get; set; }
    public string Email { get; set; } = string.Empty;
}

public class PersonInsertDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime BornDate { get; set; }
    public string Email { get; set; } = string.Empty;
}

public class PersonUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BornDate { get; set; }
    public string Email { get; set; } = string.Empty;
}
