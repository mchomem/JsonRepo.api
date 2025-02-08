namespace JsonRepo.api.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> GetAllAsync();
    Task<PersonDto?> GetByIdAsync(long id);
    Task CreateAsync(PersonInsertDto person);
    Task UpdateAsync(PersonUpdateDto person);
    Task DeleteAsync(long id);
}
