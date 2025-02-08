namespace JsonRepo.api.Interfaces;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAllAsync();
    Task<Payment> GetByIdAsync(long id);
    Task CreateAsync(Payment entity);
    Task UpdateAsync(Payment entity);
}
