namespace Quiz.DTOs.Question;
using global::Quiz.Models;

public class QuestionDto
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    //public List<string>? Options { get; set; }
    //public List<string> CorrectAnswer { get; set; } = new();
    public int QuizId { get; set; }
    public QuestionType Type { get; set; }
}