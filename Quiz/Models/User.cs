using System.Diagnostics;

namespace Quiz.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }

    public Role Role { get; set; }
    public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    public ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();
}

public enum Role
{
    Guest = 0,
    Authorized = 1,
    Admin = 2
}
