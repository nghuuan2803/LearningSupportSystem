using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models.Entities;

public class BaseEntity<T>
{
    [Key] public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
