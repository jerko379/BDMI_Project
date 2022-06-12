using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDMI.Web.Data.Migrations
{
    public partial class MoviesStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "ImdbRating", "Link", "Poster", "Title", "YearOfRelease" },
                values: new object[] { 1, null, 9.3000000000000007, "https://www.imdb.com/title/tt0111161", "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UY67_CR0,0,45,67_AL_.jpg", "Iskupljenje u Shawshanku", 1994 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "ImdbRating", "Link", "Poster", "Title", "YearOfRelease" },
                values: new object[] { 2, null, 9.1999999999999993, "https://www.imdb.com/title/tt0068646/", "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY67_CR1,0,45,67_AL_.jpg", "Kum", 1972 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "ImdbRating", "Link", "Poster", "Title", "YearOfRelease" },
                values: new object[] { 3, null, 9.0, "https://www.imdb.com/title/tt0468569", "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UY67_CR0,0,45,67_AL_.jpg", "Vitez tame", 2008 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
