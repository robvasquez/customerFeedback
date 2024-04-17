using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackSystem.Repositories;
using CustomerFeedbackSystem.Models;
using System.Threading.Tasks;
using CustomerFeedbackSystem.ViewModels;

namespace CustomerFeedbackSystem.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var feedbacks = await _repository.GetAllFeedbacks();
            var feedbackViewModels = feedbacks.Select(f => new FeedbackViewModel
            {
                FeedbackId = f.FeedbackId,  // Ensuring FeedbackId is assigned
                CustomerName = f.CustomerName,
                Category = f.Category,
                Description = f.Description,
                FormattedDate = f.SubmissionDate.ToString("MM/dd/yyyy")  // Consider moving formatting to the repository or service layer
            }).ToList();

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

        // POST: Feedback/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteFeedback(id);
            return RedirectToAction(nameof(Index));
        }
    }
}