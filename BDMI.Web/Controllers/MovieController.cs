using BDMI.Model;
using BDMI.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BDMI.Web.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _dbContext;


        public MovieController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;

        }

        public IActionResult Index()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).Include(m => m.Director).ToList();
            return View("Index", movies);

        }


        public IActionResult Create()
        {
            this.FillDropdownValues();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Movie model)
        {
            if (ModelState.IsValid)
            {
                this._dbContext.Movies.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                this.FillDropdownValues();
                return View();
            }
        }


        public IActionResult Edit(int id)
        {
            var model = this._dbContext.Movies.FirstOrDefault(m => m.Id == id);
            this.FillDropdownValues();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var movie = this._dbContext.Movies.Single(m => m.Id == id);
            var ok = await this.TryUpdateModelAsync(movie);

            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            this.FillDropdownValues();
            return View();
        }

        private void FillDropdownValues()
        {
            var selectGenres = new List<SelectListItem>();

            var listGenre = new SelectListItem();
            listGenre.Text = "";
            listGenre.Value = "";
            selectGenres.Add(listGenre);

            foreach (var genre in this._dbContext.Genres)
            {
                listGenre = new SelectListItem(genre.Name, genre.Id.ToString());
                selectGenres.Add(listGenre);
            }

            var selectDirector = new List<SelectListItem>();

            var listDirector = new SelectListItem();
            listDirector.Text = "";
            listDirector.Value = "";
            selectDirector.Add(listDirector);

            foreach (var director in this._dbContext.Directors)
            {
                listDirector = new SelectListItem(director.FirstName + " " + director.LastName, director.Id.ToString());
                selectDirector.Add(listDirector);
            }

            ViewBag.PossibleDirectors = selectDirector;
            ViewBag.PossibleGenres = selectGenres;
        }
    }
}
