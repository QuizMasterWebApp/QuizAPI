using Quiz.Models;

namespace Quiz.Services.Interfaces;

public interface IAttemptService
{
    Task<Attempt?> GetByIdAsync(int id);
    Task<IEnumerable<Attempt>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Attempt>> GetByQuizIdAsync(int quizId);

    Task<Attempt> StartAttemptAsync(int userId, int quizId);
    Task<Attempt> FinishAttemptAsync(int attemptId, IEnumerable<Answer> answers);

    Task<bool> DeleteAsync(int id);
}
