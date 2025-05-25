namespace QuizApp.Models.Entities;

public class Quiz : BaseEntity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public QuizType QuizType { get; set; } = QuizType.Normal;
    public string? AudioUrl { get; set; }
    public string? ImageUrl { get; set; }
    public virtual ICollection<Question>? Questions { get; set; }
}
public enum QuizType
{
    Normal = 0,
    Matching = 1,
    Ordering = 2,
    FillInTheBlank = 3,
    Mixed = 4,
}