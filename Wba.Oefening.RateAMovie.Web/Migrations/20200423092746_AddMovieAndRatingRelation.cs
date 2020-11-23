using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Oefening.RateAMovie.Web.Migrations
{
    public partial class AddMovieAndRatingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RatedMovieId",
                table: "Ratings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedMovieId",
                table: "Ratings",
                column: "RatedMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_RatedMovieId",
                table: "Ratings",
                column: "RatedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_RatedMovieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_RatedMovieId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "RatedMovieId",
                table: "Ratings");
        }
    }
}
