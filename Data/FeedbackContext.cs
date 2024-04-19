using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CustomerFeedbackSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerFeedbackSystem.Data
{
    public class FeedbackContext : IdentityDbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}