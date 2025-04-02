namespace UserManager.API.Dtos.User;

public class GetUserDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; set; }
}
