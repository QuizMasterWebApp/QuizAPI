using System.ComponentModel.DataAnnotations;

namespace Quiz.DTOs.Quiz;
public class QuizCreateDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Category { get; set; }
    [Required]
    public string Language { get; set; } = "Russian";
    public bool IsPublic { get; set; }
    public DateTime TimeLimit { get; set; }
}