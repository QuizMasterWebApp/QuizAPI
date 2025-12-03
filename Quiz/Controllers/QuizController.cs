using Microsoft.AspNetCore.Mvc;
using Quiz.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    // GET: api/quiz
    [HttpGet]
    public async Task<IActionResult> GetAllPublic()
    {
        var quizzes = await _quizService.GetAllPublicAsync() ?? new List<Models.Quiz>();

        if (!quizzes.Any())
            return Ok(new List<QuizDto>());

        var result = quizzes.Select(q => new QuizDto
        {
            Id = q.Id,
            Title = q.Title,
            Description = q.Description,
            Category = q.Category,
            Language = q.Language,
            IsPublic = q.isPublic,
            AuthorId = q.AuthorId,
            TimeLimit = q.TimeLimit,
            CreatedAt = q.CreatedAt
        });

        return Ok(result);
    }

    // GET: api/quiz/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var quiz = await _quizService.GetByIdAsync(id);
        if (quiz == null)
            return NotFound($"Quiz with ID {id} not found.");

        var result = new QuizDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Description = quiz.Description,
            Category = quiz.Category,
            Language = quiz.Language,
            IsPublic = quiz.isPublic,
            AuthorId = quiz.AuthorId,
            TimeLimit = quiz.TimeLimit,
            CreatedAt = quiz.CreatedAt
        };

        return Ok(result);
    }

    // GET: api/quiz/by-author/{authorId}
    [HttpGet("by-author/{authorId}")]
    public async Task<IActionResult> GetByAuthor(int authorId)
    {
        var quizzes = await _quizService.GetByAuthorAsync(authorId);

        if (!quizzes.Any())
            return Ok(new List<QuizDto>());

        var result = quizzes.Select(q => new QuizDto
        {
            Id = q.Id,
            Title = q.Title,
            Description = q.Description,
            Category = q.Category,
            Language = q.Language,
            IsPublic = q.isPublic,
            AuthorId = q.AuthorId,
            TimeLimit = q.TimeLimit,
            CreatedAt = q.CreatedAt
        });

        return Ok(result);
    }

    // POST: api/quiz
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] QuizCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var quiz = new Models.Quiz
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Language = dto.Language,
                isPublic = dto.IsPublic,
                AuthorId = dto.AuthorId,
                TimeLimit = dto.TimeLimit,
                CreatedAt = DateTime.Now
            };

            var created = await _quizService.CreateAsync(quiz);

            return Ok(new QuizDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                Category = created.Category,
                Language = created.Language,
                IsPublic = created.isPublic,
                AuthorId = created.AuthorId,
                TimeLimit= created.TimeLimit,
                CreatedAt = created.CreatedAt
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/quiz/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] QuizUpdateDto dto)
    {
        var existing = await _quizService.GetByIdAsync(id);
        if (existing == null)
            return NotFound($"Quiz with ID {id} not found.");

        existing.Title = dto.Title ?? existing.Title;
        existing.Description = dto.Description ?? existing.Description;
        existing.Category = dto.Category ?? existing.Category;
        existing.Language = dto.Language ?? existing.Language;
        existing.isPublic = dto.IsPublic ?? existing.isPublic;
        existing.TimeLimit = dto.TimeLimit ?? existing.TimeLimit;

        var success = await _quizService.UpdateAsync(existing);
        if (!success)
            return StatusCode(500, "Failed to update quiz due to server error.");

        return Ok("Updated");
    }

    // DELETE: api/quiz/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var quiz = await _quizService.GetByIdAsync(id);
        if (quiz == null)
            return NotFound($"Quiz with ID {id} not found.");
        var success = await _quizService.DeleteAsync(id);
        if (!success)
            return StatusCode(500, "Failed to delete quiz due to server error.");
        return Ok("Deleted");
    }

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

    public class QuizCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        [Required]
        public string Language { get; set; } = "Russian";
        public bool IsPublic { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public DateTime TimeLimit { get; set; }
    }

    public class QuizUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Language { get; set; }
        public bool? IsPublic { get; set; }
        public DateTime? TimeLimit { get; set; }
    }

}
