namespace JsonRepo.api.Models;

public class Payment
{
    public Payment(long personId, decimal value, DateTime paymentDate)
    {
        PersonId = personId;
        Value = value;
        PaymentDate = paymentDate;
    }

    [JsonConstructor]
    public Payment(long id, long personId, Person person, decimal value, PaymentStatus status, DateTime paymentDate, DateTime? paymentMade)
    {
        Id = id;
        PersonId = personId;
        Person = person;
        Value = value;
        Status = status;
        PaymentDate = paymentDate;
        PaymentMade = paymentMade;
    }

    public long Id { get; private set; }
    public long PersonId { get; private set; }
    public Person Person { get; private set; }
    public decimal Value { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime? PaymentMade { get; private set; }

    public void SetPaymentPending()
        => Status = PaymentStatus.Pending;

    public void SetPaymentCompleted()
    {
        Status = PaymentStatus.Completed;
        PaymentMade = DateTime.UtcNow;
    }
}
