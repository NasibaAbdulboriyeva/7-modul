using ContactSystem.Application.Dtos.UserRoleDtos;

namespace ContactSystem.Application.Dtos.UserDto;

public class UserDto
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public UserRoleDto UserRoleDto { get; set; }
}
