using Quiz.Models;
using Quiz.DTOs.Question;

namespace Quiz.Services.Interfaces;

public interface IQuestionService
{
    Task<Question?> GetByIdAsync(int id);
    Task<IEnumerable<Question>> GetByQuizAsync(int quizId);
    Task<Question> CreateAsync(Question question);
    Task<bool> UpdateAsync(Question question);
    Task<bool> DeleteAsync(int id);
}
