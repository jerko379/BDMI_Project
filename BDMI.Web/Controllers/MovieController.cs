using BDMI.Web.Data;
using Microsoft.AspNetCore.Mvc;

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

            var movies = _dbContext.Movies.ToList();
            return View("Index", movies);
        }
    }
}
