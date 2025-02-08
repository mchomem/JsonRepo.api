namespace JsonRepo.api.DTOs
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public PersonDto? Person { get; set; } = new PersonDto();
        public decimal Value { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? PaymentMade { get; set; }
    }

    public class  PaymentInsertDto
    {
        public long PersonId { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
