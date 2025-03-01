using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmSitesi.Migrations
{
    /// <inheritdoc />
    public partial class yeniupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategories_Actors_ActorId",
                table: "MovieCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategories_Movies_MovieId",
                table: "MovieCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCategories",
                table: "MovieCategories");

            migrationBuilder.RenameTable(
                name: "MovieCategories",
                newName: "MovieActor");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCategories_MovieId",
                table: "MovieActor",
                newName: "IX_MovieActor_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCategories_ActorId",
                table: "MovieActor",
                newName: "IX_MovieActor_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Actors_ActorId",
                table: "MovieActor",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Actors_ActorId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor");

            migrationBuilder.RenameTable(
                name: "MovieActor",
                newName: "MovieCategories");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieCategories",
                newName: "IX_MovieCategories_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieCategories",
                newName: "IX_MovieCategories_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCategories",
                table: "MovieCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategories_Actors_ActorId",
                table: "MovieCategories",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategories_Movies_MovieId",
                table: "MovieCategories",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
