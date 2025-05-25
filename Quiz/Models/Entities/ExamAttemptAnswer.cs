using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.Entities;

public class ExamAttemptAnswer
{
    [Key]
    public Guid Id { get; set; }

    public Guid ExamAttemptId { get; set; }
    public ExamAttempt? ExamAttempt { get; set; }

    public Guid QuestionId { get; set; }
    public Question? Question { get; set; }

    // Lưu đáp án dưới dạng JSONB để phù hợp nhiều kiểu câu hỏi
    public string AnswerJson { get; set; } = string.Empty;

    public bool? IsCorrect { get; set; }
}
