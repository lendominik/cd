using System.ComponentModel.DataAnnotations;

namespace UserManager.API.Dtos.User;

public record CreateUserDto
{
    [Required]
    public string? FirstName { get; init; }

    [Required]
    public string? LastName { get; init; }

    [Required]
    [EmailAddress]
    public string? Email { get; init; }

    [Phone]
    public string? PhoneNumber { get; set; }
}