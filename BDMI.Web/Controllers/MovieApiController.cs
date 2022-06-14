using BDMI.Model;
using BDMI.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet]
        public IActionResult Get()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).Include(m => m.Director)
                                            .Select(m => MapMovieDto(m)).ToList();
            return Ok(movies);

        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {

            var Movie = _dbContext.Movies.Include(m => m.Genre).Include(m => m.Director)
                .Where(m => m.Id == id).Select(m => MapMovieDto(m)).FirstOrDefault();


            if (Movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Movie);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie model)
        {
            Movie movie = new Movie();
            if (string.IsNullOrWhiteSpace(model.Title) || model.YearOfRelease==null || string.IsNullOrWhiteSpace(model.Poster)
                || model.ImdbRating == null || string.IsNullOrWhiteSpace(model.Link))
            {
                return BadRequest();
            }
            movie.Title = model.Title;
            movie.YearOfRelease = model.YearOfRelease;
            movie.Poster = model.Poster;
            movie.ImdbRating = model.ImdbRating;
            movie.Link = model.Link;


            if (model.DirectorId != null)
            {
                movie.DirectorId = model.DirectorId;
                movie.Director = this._dbContext.Directors.Where(d => d.Id == model.DirectorId).FirstOrDefault();

            }

            if (model.GenreId != null)
            {
                movie.GenreId = model.GenreId;
                movie.Genre = this._dbContext.Genres.Where(g => g.Id == model.GenreId).FirstOrDefault();

            }
            this._dbContext.Movies.Add(movie);
            this._dbContext.SaveChanges();

            return Get(movie.Id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Movie>> Put(int id, [FromBody] Movie model)
        {
            var Movie = this._dbContext.Movies.Single(m => m.Id == id);

            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                Movie.Title = model.Title;
            }
            if (model.YearOfRelease != null)
            {
                Movie.YearOfRelease = model.YearOfRelease;
            }
            if (model.ImdbRating != null)
            {
                Movie.ImdbRating = model.ImdbRating;
            }
            if (!string.IsNullOrWhiteSpace(model.Poster))
            {
                Movie.Poster = model.Poster;
            }

            if (!string.IsNullOrWhiteSpace(model.Link))
            {
                Movie.Link = model.Link;
            }

            if (model.DirectorId != null)
            {
                Movie.Director = this._dbContext.Directors.Where(d=> d.Id == model.DirectorId).FirstOrDefault();
            }

            if (model.GenreId != null)
            {
                Movie.Genre = this._dbContext.Genres.Where(d => d.Id == model.GenreId).FirstOrDefault();
            }


            await this._dbContext.SaveChangesAsync();

            return Ok();


        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var toDelete = _dbContext.Movies.Where(m => m.Id == id).FirstOrDefault();
            if (toDelete == null)
            {
                return BadRequest();
            }
            _dbContext.Remove(toDelete);
            this._dbContext.SaveChanges();
            return NoContent();
        }


        public static GenreDto MapGenreDto(Genre genre)
        {
            GenreDto genreDto = new GenreDto();

            genreDto.ID = genre.Id;
            genreDto.Name = genre.Name;

            return genreDto;

        }
        public static DirectorDTO MapDirectorDto(Director director)
        {
            DirectorDTO directorDto = new DirectorDTO();

            directorDto.ID = director.Id;
            directorDto.FullName = director.FullName;
            directorDto.NumberOfMovies = director.Movies.Count;

            return directorDto;

        }
        public static MovieDTO MapMovieDto(Movie movie)
        {

            MovieDTO movieDto = new MovieDTO();
            movieDto.ID = movie.Id;
            movieDto.Title = movie.Title;
            movieDto.YearOfRelease = movie.YearOfRelease;
            movieDto.ImdbRating = movie.ImdbRating;
            movieDto.Link = movie.Link;
            movieDto.Director = MapDirectorDto(movie.Director);
            movieDto.Genre = MapGenreDto(movie.Genre);

            return movieDto;

        }
    }
}




public class MovieDTO
{
    public int ID { get; set; }

    public string Title { get; set; }

    public int YearOfRelease { get; set; }
    public double? ImdbRating { get; set; }

    public string Link { get; set; }


    public DirectorDTO? Director { get; set; }

    public GenreDto? Genre { get; set; }







}


public class DirectorDTO
{
    public int ID { get; set; }
    public string FullName { get; set; }
    public int NumberOfMovies { get; set; }


}

public class GenreDto
{
    public int ID { get; set; }
    public string Name { get; set; }

}

