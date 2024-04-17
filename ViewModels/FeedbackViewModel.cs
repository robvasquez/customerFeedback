namespace CustomerFeedbackSystem.ViewModels;

public class FeedbackViewModel
{
    public int FeedbackId { get; set; }
    public string CustomerName { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string FormattedDate { get; set; }
}