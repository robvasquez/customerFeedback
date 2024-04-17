using System;

namespace CustomerFeedbackSystem.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime SubmissionDate { get; set; }
    }
}