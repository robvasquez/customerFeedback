using Microsoft.EntityFrameworkCore;
using CustomerFeedbackSystem.Models;

namespace CustomerFeedbackSystem.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}