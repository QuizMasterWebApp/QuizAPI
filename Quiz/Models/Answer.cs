namespace Quiz.Models;

public class Answer
{
    public int Id { get; set; }
    public string UserAnswer { get; set; }
    public bool IsCorrect { get; set; }
    public int AttemptId { get; set; }
    public int QuestionId { get; set; }

    public Attempt Attempt { get; set; }
    public Question Question { get; set; }
}
