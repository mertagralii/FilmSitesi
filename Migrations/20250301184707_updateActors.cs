using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmSitesi.Migrations
{
    /// <inheritdoc />
    public partial class updateActors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Actors");
        }
    }
}
