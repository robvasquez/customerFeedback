// File: Repositories/IFeedbackRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerFeedbackSystem.Models;

namespace CustomerFeedbackSystem.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback?> GetFeedbackById(int id);
        Task AddFeedback(Feedback feedback);
        Task UpdateFeedback(Feedback feedback);
        Task DeleteFeedback(int id);
    }
}