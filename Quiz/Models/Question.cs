namespace Quiz.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    //public int QuestionTypeId { get; set; }
    public List<string>? Options { get; set; }
    public List<string> CorrectAnswer { get; set; }
    public int QuizId { get; set; }

    public QuestionType Type { get; set; }
    public Quiz Quiz { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}

public enum QuestionType
{
    Single = 0,
    Multiple = 1,
    Open = 2
}