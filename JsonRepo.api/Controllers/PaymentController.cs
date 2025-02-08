namespace JsonRepo.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
        => _paymentService = paymentService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var payment = await _paymentService.GetAllAsync();
        return Ok(payment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        var payment = await _paymentService.GetByIdAsync(id);
        return payment == null ? NotFound() : Ok(payment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(PaymentInsertDto payment)
    {
        await _paymentService.CreateAsync(payment);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> CompletePaymentAsync(long id)
    {
        await _paymentService.CompletePaymentAsync(id);
        return NoContent();
    }
}
