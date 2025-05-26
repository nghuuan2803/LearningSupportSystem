using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Models.Entities;

namespace QuizApp.Data;

public class QuizDbContext(DbContextOptions<QuizDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<ExamCandidate> ExamCandidates => Set<ExamCandidate>();
    public DbSet<ExamAttempt> ExamAttempts => Set<ExamAttempt>();
    public DbSet<ExamAttemptAnswer> ExamAttemptAnswers => Set<ExamAttemptAnswer>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Question>().Property(p => p.ContentJson).HasColumnType("jsonb");
        builder.Entity<ExamAttemptAnswer>().Property(p => p.AnswerJson).HasColumnType("jsonb");

        // ExamCandidate: Composite Key
        builder.Entity<ExamCandidate>()
            .HasKey(ec => new { ec.ExamId, ec.CandidateId });

        // ExamCandidate → Exam
        builder.Entity<ExamCandidate>()
            .HasOne(ec => ec.Exam)
            .WithMany(e => e.EnrolledCandidates)
            .HasForeignKey(ec => ec.ExamId)
            .OnDelete(DeleteBehavior.Cascade);

        // ExamCandidate → ApplicationUser
        builder.Entity<ExamCandidate>()
            .HasOne(ec => ec.Candidate)
            .WithMany(u => u.EnrolledExams)
            .HasForeignKey(ec => ec.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);

        // Exam → CreatedUser
        builder.Entity<Exam>()
            .HasOne(e => e.CreatedUser)
            .WithMany(u => u.CreatedExams)
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict); // tránh xóa cascade user → exam

        // ExamAttempt → Candidate
        builder.Entity<ExamAttempt>()
            .HasOne(ea => ea.Candidate)
            .WithMany(u => u.ExamAttempts)
            .HasForeignKey(ea => ea.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);

        // ExamAttemptAnswer → ExamAttempt
        builder.Entity<ExamAttemptAnswer>()
            .HasOne(eaa => eaa.ExamAttempt)
            .WithMany()
            .HasForeignKey(eaa => eaa.ExamAttemptId);

        // ExamAttemptAnswer → Question
        builder.Entity<ExamAttemptAnswer>()
            .HasOne(eaa => eaa.Question)
            .WithMany()
            .HasForeignKey(eaa => eaa.QuestionId);

        // Quiz → ApplicationUser
        builder.Entity<Quiz>()
            .HasOne<ApplicationUser>()
            .WithMany(u => u.Quizzes)
            .HasForeignKey("CreatedUserId")
            .OnDelete(DeleteBehavior.Restrict); // optional nếu bạn cần tracking người tạo quiz

        // Question → Quiz
        builder.Entity<Question>()
            .HasOne(q => q.Quiz)
            .WithMany(qz => qz.Questions)
            .HasForeignKey(q => q.QuizId);
    }
}
