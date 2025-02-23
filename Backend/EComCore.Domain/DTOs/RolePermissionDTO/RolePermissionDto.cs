namespace EComCore.Domain.DTOs
{
    public class RolePermissionDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int PermissionId { get; set; }
        public PermissionDto Permission { get; set; }
    }
}