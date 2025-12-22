namespace Quiz.DTOs.Question;
using global::Quiz.Models;

public class QuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public int? QuizId { get; set; }
    public List<OptionDto> Options { get; set; } = new List<OptionDto>();
}