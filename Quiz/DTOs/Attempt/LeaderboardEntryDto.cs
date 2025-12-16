namespace Quiz.DTOs.Attempt;

public class LeaderboardEntryDto
{
    public string UserName { get; set; } = string.Empty;
    public int Score { get; set; }
    public TimeSpan TimeSpent { get; set; }
    public DateTime CompletedAt { get; set; }
}