using System.ComponentModel.DataAnnotations;

namespace Quiz.DTOs.User;

public class AuthDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = string.Empty;
}