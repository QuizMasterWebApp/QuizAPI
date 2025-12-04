using System.ComponentModel.DataAnnotations;
using Quiz.Models;

namespace Quiz.DTOs.Question;
public class QuestionCreateDto
{
    [Required]
    public string Text { get; set; } = string.Empty;
    [Required]
    public int QuizId { get; set; }
    [Required]
    public QuestionType Type { get; set; }
    public List<string>? Options { get; set; }
    public List<string>? CorrectAnswer { get; set; }
}