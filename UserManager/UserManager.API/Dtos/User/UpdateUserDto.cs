using System.ComponentModel.DataAnnotations;

namespace UserManager.API.Dtos.User;

public record UpdateUserDto
{
    [EmailAddress]
    public string? Email { get; init; }

    [Phone]
    public string? PhoneNumber { get; set; }
}
