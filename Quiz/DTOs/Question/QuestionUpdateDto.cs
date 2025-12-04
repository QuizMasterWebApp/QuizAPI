using System.ComponentModel.DataAnnotations;
using Quiz.Models;

namespace Quiz.DTOs.Question;
public class QuestionUpdateDto
{
    public string? Text { get; set; }
    public QuestionType? Type { get; set; }
    public List<string> Options { get; set; }
    public List<string> CorrectAnswer { get; set; }
}
