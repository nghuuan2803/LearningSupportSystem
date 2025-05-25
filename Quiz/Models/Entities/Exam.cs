namespace QuizApp.Models.Entities
{
    public class Exam : BaseEntity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? MaxAttempts { get; set; } // Số lần thi tối đa
        public int? DurationInMinutes { get; set; } // Thời gian giới hạn
        public bool AutoSubmit { get; set; } // Tự submit nếu tới gian kết thúc (EndAt)
        public bool ShuffleOptions { get; set; } // Trộn câu hỏi
        public bool ShowExplanationAfterSubmit { get; set; } // Hiện giải thích sau khi nộp
        public bool AllowViewResult { get; set; } = false;
        public bool AllowEnroll { get; set; } = true; // Cho phép tự ghi danh
        public bool CandidateCodeRequire { get; set; } = true; // Yêu cầu nhập mã thí sinh khi ghi danh
        public double? EnrollFee { get; set; } //Phí ghi danh
        public virtual ICollection<ExamCandidate>? EnrolledCandidates { get; set; }
        public virtual ICollection<ExamAttempt>? ExamAttempts { get; set; }
        public virtual ApplicationUser? CreatedUser { get; set; }
        public Guid? QuizId { get; set; }
        public Quiz? Quiz { get; set; }
    }
}
