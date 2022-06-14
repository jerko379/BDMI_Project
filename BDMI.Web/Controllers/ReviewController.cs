using BDMI.Model;
using BDMI.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDMI.Web.Controllers
{
    public class ReviewController : Controller
    {

        private ApplicationDbContext _dbContext;


        public ReviewController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            var reviews = _dbContext.Reviews.Include(r => r.Movie).ToList();
            return View("Index", reviews);
        }

        public IActionResult Details(int? id = null)
        {
            var review = this._dbContext.Reviews
                .Include(r => r.Movie)
                .Where(r => r.Id == id)
                .FirstOrDefault();
            return View("Details", review);
        }


        public IActionResult Create(int movieid)
        {
            ViewBag.MovieId = movieid;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review model)
        {

            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToList();
            if (ModelState.IsValid)
            {
                Movie movie = this._dbContext.Movies.Where(m => m.Id == model.MovieId).FirstOrDefault();
                model.Movie = movie;
                this._dbContext.Reviews.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }


        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Reviews.FirstOrDefault(m => m.Id == id);
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var review = this._dbContext.Reviews.Single(m => m.Id == id);
            var ok = await this.TryUpdateModelAsync(review);

            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
                .SelectMany(E => E.Errors)
                .Select(E => E.ErrorMessage)
                .ToList();
            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var toDelete = _dbContext.Reviews.Where(m => m.Id == id).FirstOrDefault();
            _dbContext.Remove(toDelete);
            this._dbContext.SaveChanges();
            return Index();
        }
    }
}
