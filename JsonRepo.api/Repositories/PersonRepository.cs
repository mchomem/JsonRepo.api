namespace JsonRepo.api.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly IRepository<Person> _repository;

    public PersonRepository(IRepository<Person> repository)
        => _repository = repository;

    public async Task CreateAsync(Person entity)
        => await _repository.CreateAsync(entity);

    public async Task DeleteAsync(long id)
        => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<Person>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<Person> GetByIdAsync(long id)
        => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Person entity)
        => await _repository.UpdateAsync(entity);
}
