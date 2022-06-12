using BDMI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDMI.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie>? Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Director>().HasData(new Director{Id = 1, FirstName = "Frank", LastName = "Darabont" , Link= "https://www.imdb.com/name/nm0001104"} );
            modelBuilder.Entity<Director>().HasData(new Director { Id = 2, FirstName = "Francis", LastName = "Ford Coppola", Link = "https://www.imdb.com/name/nm0000338" });
            modelBuilder.Entity<Director>().HasData(new Director { Id = 3, FirstName = "Christopher", LastName = "Nolan", Link = "https://www.imdb.com/name/nm0634240" });
            modelBuilder.Entity<Director>().HasData(new Director { Id = 4, FirstName = "Steven", LastName = "Spielberg", Link = "https://www.imdb.com/name/nm0000229" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 1, Name = "Comedy", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Comedy._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 2, Name = "Sci-fi", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Sci-Fi._CB1513316168_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 3, Name = "Horror", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Horror._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 4, Name = "Romance", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Romance._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 5, Name = "Action", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Action._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 6, Name = "Thriller", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Thriler._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 7, Name = "Drama", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Drama._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 8, Name = "Mystery", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Mystery._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 9, Name = "Crime", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Crime._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 10, Name = "Animation", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Animation._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 11, Name = "Adventure", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Adventure._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });
            modelBuilder.Entity<Genre>().HasData(new Genre { Id = 12, Name = "Fantasy", CoverLink = "https://m.media-amazon.com/images/G/01/IMDb/genres/Fantasy._CB1513316167_SX233_CR0,0,233,131_AL_.jpg" });


            //modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1,  Title = "Iskupljenje u Shawshanku", ImdbRating = 9.3, Link = "https://www.imdb.com/title/tt0111161", Poster = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UY67_CR0,0,45,67_AL_.jpg", YearOfRelease = 1994 });
            //modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "Kum", ImdbRating = 9.2, Link = "https://www.imdb.com/title/tt0068646/", Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY67_CR1,0,45,67_AL_.jpg", YearOfRelease = 1972 });
            //modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Title = "Vitez tame", ImdbRating = 9.0, Link = "https://www.imdb.com/title/tt0468569", Poster = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UY67_CR0,0,45,67_AL_.jpg", YearOfRelease = 2008 });
        }
    }
}