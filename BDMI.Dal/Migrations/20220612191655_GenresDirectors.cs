using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDMI.Web.Data.Migrations
{
    public partial class GenresDirectors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName", "Link" },
                values: new object[,]
                {
                    { 1, "Frank", "Darabont", "https://www.imdb.com/name/nm0001104" },
                    { 2, "Francis", "Ford Coppola", "https://www.imdb.com/name/nm0000338" },
                    { 3, "Christopher", "Nolan", "https://www.imdb.com/name/nm0634240" },
                    { 4, "Steven", "Spielberg", "https://www.imdb.com/name/nm0000229" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CoverLink", "Name" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/G/01/IMDb/genres/Comedy._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Comedy" },
                    { 2, "https://m.media-amazon.com/images/G/01/IMDb/genres/Sci-Fi._CB1513316168_SX233_CR0,0,233,131_AL_.jpg", "Sci-fi" },
                    { 3, "https://m.media-amazon.com/images/G/01/IMDb/genres/Horror._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Horror" },
                    { 4, "https://m.media-amazon.com/images/G/01/IMDb/genres/Romance._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Romance" },
                    { 5, "https://m.media-amazon.com/images/G/01/IMDb/genres/Action._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Action" },
                    { 6, "https://m.media-amazon.com/images/G/01/IMDb/genres/Thriler._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Thriller" },
                    { 7, "https://m.media-amazon.com/images/G/01/IMDb/genres/Drama._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Drama" },
                    { 8, "https://m.media-amazon.com/images/G/01/IMDb/genres/Mystery._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Mystery" },
                    { 9, "https://m.media-amazon.com/images/G/01/IMDb/genres/Crime._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Crime" },
                    { 10, "https://m.media-amazon.com/images/G/01/IMDb/genres/Animation._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Animation" },
                    { 11, "https://m.media-amazon.com/images/G/01/IMDb/genres/Adventure._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Adventure" },
                    { 12, "https://m.media-amazon.com/images/G/01/IMDb/genres/Fantasy._CB1513316167_SX233_CR0,0,233,131_AL_.jpg", "Fantasy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Movies");
        }
    }
}
