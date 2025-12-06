namespace Quiz.DTOs.Answer;
public class AnswerDto
{
    public int Id { get; set; }
    public string UserAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public int AttemptId { get; set; }
    public int QuestionId { get; set; }
}