namespace QuizApp.Models.Entities;

public class ExamCandidate
{
    public Guid ExamId { get; set; }
    public Exam? Exam { get; set; }

    public string CandidateId { get; set; } = default!;
    public ApplicationUser? Candidate { get; set; } = default!;
    public DateTime EnrollAt { get; set; } = DateTime.UtcNow;
    public string? CandidateCode { get; set; }
}
