namespace JsonRepo.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService service)
        => _personService = service;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var people = await _personService.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var person = await _personService.GetByIdAsync(id);
        return person == null ? NotFound() : Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(PersonInsertDto person)
    {
        await _personService.CreateAsync(person);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, PersonUpdateDto person)
    {
        if (id != person.Id) return BadRequest();

        await _personService.UpdateAsync(person);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        await _personService.DeleteAsync(id);
        return NoContent();
    }
}
