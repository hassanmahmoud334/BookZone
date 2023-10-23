using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookZone.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createCategorytablewithdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Action" },
                    { 3, "Romance" },
                    { 4, "Science Fiction" },
                    { 5, "Horror" },
                    { 6, "Thriller" },
                    { 7, "Mystery" },
                    { 8, "Crime" },
                    { 9, "Historical Fiction" },
                    { 10, "Cooking" },
                    { 11, "Art" },
                    { 12, "Self-help / Personal" },
                    { 13, "Development" },
                    { 14, "Motivational" },
                    { 15, "Health" },
                    { 16, "History" },
                    { 17, "Travel" },
                    { 18, "Guide / How-to" },
                    { 19, "Families & Relationships" },
                    { 20, "Humor" },
                    { 21, "Children's" },
                    { 22, "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
