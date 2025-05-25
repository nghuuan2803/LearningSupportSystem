using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.Entities;

public class BaseEntity<T>
{
    [Key] public virtual T Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
