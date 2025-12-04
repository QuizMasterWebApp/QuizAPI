using System.ComponentModel.DataAnnotations;

namespace Quiz.DTOs.User;

public class UserUpdateDto
{
    public string? UserName { get; set; }
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string? Password { get; set; }
}