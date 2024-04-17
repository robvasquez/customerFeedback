using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerFeedbackSystem.Data;
using CustomerFeedbackSystem.Models;

namespace CustomerFeedbackSystem.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackContext _context;

        public FeedbackRepository(FeedbackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback?> GetFeedbackById(int id)
        {
            return await _context.Feedbacks.FirstOrDefaultAsync(f => f.FeedbackId == id);
        }

        public async Task AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeedback(Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}