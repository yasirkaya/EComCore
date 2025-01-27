namespace EComCore.Domain.DTOs.AddressDTO
{
    public class CreateAddressDto
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}