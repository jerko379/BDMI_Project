using BDMI.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace BDMI.Web.Controllers
{

    [Route("api/movies")]
    [ApiController]
    public class MovieApiController : Controller
    {

        private ApplicationDbContext _dbContext;



        public MovieApiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var toDelete = _dbContext.Movies.Where(m => m.Id == id).FirstOrDefault();
            if (toDelete != null)
            {
                return BadRequest();
            }
            _dbContext.Remove(toDelete);
            this._dbContext.SaveChanges();
            return NoContent();
        }
    }
}
