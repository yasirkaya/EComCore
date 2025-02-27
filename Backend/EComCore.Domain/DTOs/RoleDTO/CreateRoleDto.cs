namespace EComCore.Domain.DTOs;

public class CreateRoleDto
{
    public string Name { get; set; }
    public IEnumerable<int> PermissionIds { get; set; }
}
