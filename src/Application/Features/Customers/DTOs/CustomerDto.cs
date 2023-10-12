namespace SmartGenealogy.Application.Features.Customers.DTOs;

[Description("Customers")]
public class CustomerDto
{
    // TODO: define data transfer object (TDO) fields, for example:
    [Description("Id")]
    public int Id { get; set; }

    [Description("Name")]
    public string Name { get; set; } = String.Empty;

    [Description("Description")]
    public string? Description { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}