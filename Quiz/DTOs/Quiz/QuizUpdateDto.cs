using System.ComponentModel.DataAnnotations;

namespace Quiz.DTOs.Quiz;

public class QuizUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Language { get; set; }
        public bool? IsPublic { get; set; }
        public DateTime? TimeLimit { get; set; }
    }