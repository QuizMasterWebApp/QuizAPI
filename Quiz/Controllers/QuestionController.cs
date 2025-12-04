using Microsoft.AspNetCore.Mvc;
using Quiz.Models;
using Quiz.DTOs.Question;
using Quiz.Services.Implementations;
using Quiz.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    // GET: api/question/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var q = await _questionService.GetByIdAsync(id);
        if (q == null)
            return NotFound($"Question with ID {id} not found.");

        return Ok(new QuestionDto
        {
            Id = q.Id,
            Text = q.Text,
            Type = q.Type,
            Options = q.Options,
            CorrectAnswer = q.CorrectAnswer,
            QuizId = q.QuizId
        });
    }

    // GET: api/question/by-quiz/{quizId}
    [HttpGet("by-quiz/{quizId}")]
    public async Task<IActionResult> GetByQuiz(int quizId)
    {
        var questions = await _questionService.GetByQuizAsync(quizId);

        if (!questions.Any())
            return Ok(new List<QuestionDto>());

        var result = questions.Select(q => new QuestionDto
        {
            Id = q.Id,
            Text = q.Text,
            Type = q.Type,
            Options = q.Options,
            CorrectAnswer = q.CorrectAnswer,
            QuizId = q.QuizId
        });

        return Ok(result);
    }

    // POST: api/question
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] QuestionCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var question = new Question
            {
                Text = dto.Text,
                QuizId = dto.QuizId,
                Type = dto.Type,
                Options = dto.Options ?? new List<string>(),
                CorrectAnswer = dto.CorrectAnswer ?? new List<string>()
            };

            var created = await _questionService.CreateAsync(question);

            return Ok(new QuestionDto
            {
                Id = created.Id,
                Text = created.Text,
                Type = created.Type,
                Options = created.Options,
                CorrectAnswer = created.CorrectAnswer,
                QuizId = created.QuizId
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/question/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] QuestionUpdateDto dto)
    {
        var existing = await _questionService.GetByIdAsync(id);
        if (existing == null)
            return NotFound($"Question with ID {id} not found.");

        existing.Text = dto.Text ?? existing.Text;
        existing.Type = dto.Type ?? existing.Type;
        existing.Options = dto.Options ?? existing.Options;
        existing.CorrectAnswer = dto.CorrectAnswer ?? existing.CorrectAnswer;

        var success = await _questionService.UpdateAsync(existing);
        if (!success)
            return StatusCode(500, "Failed to update question.");

        return Ok("Updated");
    }

    // DELETE: api/question/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var question = await _questionService.GetByIdAsync(id);
        if (question == null)
            return NotFound($"Question with ID {id} not found.");

        var success = await _questionService.DeleteAsync(id);
        if (!success)
            return StatusCode(500, "Failed to delete question due to server error.");

        return Ok("Deleted");
    }
}