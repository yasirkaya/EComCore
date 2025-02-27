namespace EComCore.Domain.DTOs
{
    public class UpdateRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}