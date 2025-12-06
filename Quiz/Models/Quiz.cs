namespace Quiz.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public bool isPublic { get; set; } = true;
    public TimeSpan? TimeLimit  { get; set; }
    public int AuthorId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User Author { get; set; }
    public Category? Category { get; set; }
    public ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
