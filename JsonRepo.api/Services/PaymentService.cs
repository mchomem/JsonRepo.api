namespace JsonRepo.api.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public PaymentService(IPaymentRepository paymentRepository, IPersonService personService, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _personService = personService;
        _mapper = mapper;
    }

    public async Task CreateAsync(PaymentInsertDto entity)
    {
        var payment = _mapper.Map<Payment>(entity);
        payment.SetPaymentPending();
        await _paymentRepository.CreateAsync(payment);
    }

    public async Task CompletePaymentAsync(long id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);
        payment.SetPaymentCompleted();
        await _paymentRepository.UpdateAsync(payment);
    }

    public async Task<IEnumerable<PaymentDto>> GetAllAsync()
    {
        var payments = await _paymentRepository.GetAllAsync();

        List<PaymentDto> paymentDtos = new();

        foreach (var item in payments)
        {
            var person = await _personService.GetByIdAsync(item.PersonId);
            var personDto = _mapper.Map<PersonDto>(person);
            var paymentDto = _mapper.Map<PaymentDto>(item);
            paymentDto.Person = personDto ?? null;
            paymentDtos.Add(paymentDto);
        }

        return paymentDtos.AsEnumerable();
    }

    public async Task<PaymentDto?> GetByIdAsync(long id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);

        if (payment is null)
            return null;

        var person = await _personService.GetByIdAsync(payment.PersonId);
        var paymentDto = _mapper.Map<PaymentDto>(payment);

        if (person != null)
        {
            paymentDto.Person = _mapper.Map<PersonDto>(person);
        }

        return paymentDto;
    }
}
