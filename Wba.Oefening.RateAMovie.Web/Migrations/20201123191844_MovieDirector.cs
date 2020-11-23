using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Oefening.RateAMovie.Web.Migrations
{
    public partial class MovieDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirector_Directors_DirectorId",
                table: "MovieDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirector_Movies_MovieId",
                table: "MovieDirector");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirector",
                table: "MovieDirector");

            migrationBuilder.RenameTable(
                name: "MovieDirector",
                newName: "MovieDirectors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirector_DirectorId",
                table: "MovieDirectors",
                newName: "IX_MovieDirectors_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors",
                columns: new[] { "MovieId", "DirectorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorId",
                table: "MovieDirectors",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Directors_DirectorId",
                table: "MovieDirectors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirectors_Movies_MovieId",
                table: "MovieDirectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDirectors",
                table: "MovieDirectors");

            migrationBuilder.RenameTable(
                name: "MovieDirectors",
                newName: "MovieDirector");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDirectors_DirectorId",
                table: "MovieDirector",
                newName: "IX_MovieDirector_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDirector",
                table: "MovieDirector",
                columns: new[] { "MovieId", "DirectorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirector_Directors_DirectorId",
                table: "MovieDirector",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirector_Movies_MovieId",
                table: "MovieDirector",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
