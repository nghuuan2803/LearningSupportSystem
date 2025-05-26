using System.ComponentModel.DataAnnotations;
namespace QuizApp.Models.Entities;

public class ExamAttempt
{
    [Key]
    public Guid Id { get; set; }

    public string CandidateId { get; set; }
    public ApplicationUser? Candidate { get; set; }

    public Guid ExamId { get; set; }
    public Exam? Exam { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public ExamAttemptStatus Status { get; set; }
    public double? Score { get; set; }
}
public enum ExamAttemptStatus
{
    InProgress,
    Submitted,
    Expired
}
