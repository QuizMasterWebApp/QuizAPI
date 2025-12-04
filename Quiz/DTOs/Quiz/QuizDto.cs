namespace Quiz.DTOs.Quiz;
public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string Language { get; set; } = "Russian";
    public bool IsPublic { get; set; }
    public int AuthorId { get; set; }
    public DateTime? TimeLimit { get; set; }
    public DateTime CreatedAt { get; set; }
}