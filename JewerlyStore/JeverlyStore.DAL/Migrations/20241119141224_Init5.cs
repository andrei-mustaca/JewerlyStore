using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeverlyStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoriesPicture",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    idCategories = table.Column<Guid>(type: "uuid", nullable: false),
                    pathImg = table.Column<string>(type: "text", nullable: false),
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriesPicture", x => x.id);
                    table.ForeignKey(
                        name: "FK_categoriesPicture_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoriesPicture_CategoriesId",
                table: "categoriesPicture",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriesPicture");
        }
    }
}
