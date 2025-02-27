namespace EComCore.Domain.DTOs;

public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<PermissionDto> Permissions { get; set; }
}