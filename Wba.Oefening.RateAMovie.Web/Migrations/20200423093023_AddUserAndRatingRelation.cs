using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Oefening.RateAMovie.Web.Migrations
{
    public partial class AddUserAndRatingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReviewerId",
                table: "Ratings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ReviewerId",
                table: "Ratings",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_ReviewerId",
                table: "Ratings",
                column: "ReviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_ReviewerId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ReviewerId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Ratings");
        }
    }
}
