namespace EComCore.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IEnumerable<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

}