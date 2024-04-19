using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackSystem.Repositories;
using CustomerFeedbackSystem.Models;
using System.Threading.Tasks;
using CustomerFeedbackSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace CustomerFeedbackSystem.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMemoryCache _memoryCache;

        public FeedbackController(IFeedbackRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            string cacheKey = "feedbackList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<FeedbackViewModel> feedbackViewModels))
            {
                var feedbacks = await _repository.GetAllFeedbacks();
                feedbackViewModels = feedbacks.Select(f => new FeedbackViewModel
                {
                    FeedbackId = f.FeedbackId,
                    CustomerName = f.CustomerName,
                    Category = f.Category,
                    Description = f.Description,
                    FormattedDate = f.SubmissionDate.ToString("MM/dd/yyyy")
                }).ToList();

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5)) // Cache data for 5 minutes
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)); // Absolute expiration time of 1 hour

                _memoryCache.Set(cacheKey, feedbackViewModels, cacheEntryOptions);
            }

            return View(feedbackViewModels);
        }

        // GET: Feedback/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,Category,Description,SubmissionDate")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddFeedback(feedback);
                _memoryCache.Remove("feedbackList"); // Invalidate the cache
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // GET: Feedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _repository.GetFeedbackById(id.Value);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedback/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("FeedbackId,CustomerName,Category,Description,SubmissionDate")]
            Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.UpdateFeedback(feedback);
                _memoryCache.Remove("feedbackList"); // Invalidate the cache
                return RedirectToAction(nameof(Index));
            }

            return View(feedback);
        }
        
        // GET: Feedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _repository.GetFeedbackById(id.Value);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }
        
        // GET: Feedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _repository.GetFeedbackById(id.Value);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteFeedback(id);
            _memoryCache.Remove("feedbackList"); // Invalidate the cache
            return RedirectToAction(nameof(Index));
        }
    }
}