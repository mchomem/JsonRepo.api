namespace JsonRepo.api.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var people = await _personRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PersonDto>>(people);
    }

    public async Task<PersonDto?> GetByIdAsync(long id)
    {
        var person = await _personRepository.GetByIdAsync(id)!;
        return _mapper.Map<PersonDto?>(person);
    }

    public async Task CreateAsync(PersonInsertDto person)
    {
        var entity = _mapper.Map<Person>(person);
        await _personRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(PersonUpdateDto person)
    {
        var entity = _mapper.Map<Person>(person);
        await _personRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(long id)
        => await _personRepository.DeleteAsync(id);
}
