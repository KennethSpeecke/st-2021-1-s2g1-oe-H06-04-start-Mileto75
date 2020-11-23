using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Oefening.RateAMovie.Web.Migrations
{
    public partial class UnshadowKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_RatedMovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_ReviewerId",
                table: "Ratings");

            migrationBuilder.AlterColumn<long>(
                name: "ReviewerId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RatedMovieId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_RatedMovieId",
                table: "Ratings",
                column: "RatedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_ReviewerId",
                table: "Ratings",
                column: "ReviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_RatedMovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_ReviewerId",
                table: "Ratings");

            migrationBuilder.AlterColumn<long>(
                name: "ReviewerId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "RatedMovieId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_RatedMovieId",
                table: "Ratings",
                column: "RatedMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_ReviewerId",
                table: "Ratings",
                column: "ReviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
