using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeverlyStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_requests_RequestId",
                table: "requests");

            migrationBuilder.DropIndex(
                name: "IX_requests_RequestId",
                table: "requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "requests");

            migrationBuilder.RenameColumn(
                name: "idRequest",
                table: "requests",
                newName: "idOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idOrder",
                table: "requests",
                newName: "idRequest");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "requests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestId",
                table: "requests",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_requests_RequestId",
                table: "requests",
                column: "RequestId",
                principalTable: "requests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
