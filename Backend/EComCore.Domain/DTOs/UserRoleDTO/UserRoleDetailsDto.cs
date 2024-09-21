namespace EComCore.Domain.DTOs.UserRoleDTO;

public class UserRoleDetailsDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }

}