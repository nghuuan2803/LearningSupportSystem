using Microsoft.AspNetCore.Identity;
namespace QuizApp.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public DateTime? DoB { get; set; }
    public Gender? Gender { get; set; }
    public string? BankCardNumber { get; set; }
    public string? BankName { get; set; }

    public virtual ICollection<Quiz>? Quizzes { get; set; }
    public virtual ICollection<Exam>? CreatedExams { get; set; }
    public virtual ICollection<ExamCandidate>? EnrolledExams { get; set; }
    public virtual ICollection<ExamAttempt>? ExamAttempts { get; set; }
}
public enum Gender { Male, Female, Other }

