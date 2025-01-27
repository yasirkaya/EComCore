namespace EComCore.Domain.DTOs.AddressDTO;

public class AddressDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public bool IsDeleted { get; set; }
}