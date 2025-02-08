namespace JsonRepo.api.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAllAsync();
    Task<PaymentDto?> GetByIdAsync(long id);
    Task CreateAsync(PaymentInsertDto entity);
    Task CompletePaymentAsync(long id);
}
