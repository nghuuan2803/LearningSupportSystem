namespace QuizApp.Models.Entities;

public class Question : BaseEntity<Guid>
{
    public string QuestionText { get; set; } = string.Empty;
    public string? AudioUrl { get; set; }
    public string? ImageUrl { get; set; }
    public int? Type { get; set; }
    public string? Matching { get; set; }
    public string ContentJson { get; set; } = string.Empty;
    public int? Difficulty { get; set; }
    public double? Point { get; set; }
    public Guid QuizId { get; set; }
    public virtual Quiz? Quiz { get; set; }
}

public enum QuestionType
{
    SingleChoice,
    MultiChoice,
    FillInTheBlank,
    Matching,
    Ordering
}