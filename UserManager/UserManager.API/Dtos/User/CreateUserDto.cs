using System.ComponentModel.DataAnnotations;

namespace UserManager.API.Dtos.User;

public record CreateUserDto
{
    [Required]
    public required string FirstName { get; init; }

    [Required]
    public required string LastName { get; init; }

    [Required]
    [EmailAddress]
    public required string Email { get; init; }

    [Phone]
    public string? PhoneNumber { get; set; }
}