namespace Quiz.Models;

public class Attempt
{
    public int Id { get; set; }
    public int Score { get; set; }
    public DateTime TimeSpent { get; set; }
    public DateTime CompletedAt { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }

    public User User { get; set; }
    public Quiz Quiz { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
