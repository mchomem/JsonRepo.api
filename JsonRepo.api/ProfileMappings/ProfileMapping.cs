namespace JsonRepo.api.ProfileMappings;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Person, PersonInsertDto>().ReverseMap();
        CreateMap<Person, PersonUpdateDto>().ReverseMap();

        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Payment, PaymentInsertDto>().ReverseMap();
    }
}
