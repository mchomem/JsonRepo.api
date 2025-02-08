namespace JsonRepo.api.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IRepository<Payment> _paymentRepository;

    public PaymentRepository(IRepository<Payment> paymentRepository)
        => _paymentRepository = paymentRepository;

    public async Task CreateAsync(Payment entity)
        => await _paymentRepository.CreateAsync(entity);

    public Task UpdateAsync(Payment entity)
        => _paymentRepository.UpdateAsync(entity);

    public async Task<IEnumerable<Payment>> GetAllAsync()
        => await _paymentRepository.GetAllAsync();

    public async Task<Payment> GetByIdAsync(long id)
        => await _paymentRepository.GetByIdAsync(id);
}
