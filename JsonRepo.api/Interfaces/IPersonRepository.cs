namespace JsonRepo.api.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> GetByIdAsync(long id);
    Task CreateAsync(Person entity);
    Task UpdateAsync(Person entity);
    Task DeleteAsync(long id);
}
